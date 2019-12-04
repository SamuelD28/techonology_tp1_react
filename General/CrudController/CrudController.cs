using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Technology_Tp1_React.General.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using JetBrains.Annotations;

namespace Technology_Tp1_React.General.CrudController
{
    /// <summary>
    /// Generic controller class that handles the interaction with an entity model
    /// </summary>
    /// <typeparam name="T">IEntity Model to handle</typeparam>
    public abstract class CrudController<T> : Controller where T : class, IEntity
    {
        protected readonly IRepository<T> Repository;

        /// <summary>
        /// Default Constructor. 
        /// </summary>
        /// <param name="repository"></param>
        public CrudController(IRepository<T> repository)
        {
            Repository = repository;
        }

        private string CreateNavigationQuery(string url, int start, int end)
            => $"{url}?start={start}&end={end}";

        private string CreatePreviousNavigationQuery(string url,int start, int end)
        {
            return start.Equals(0)
                    ? null
                    : CreateNavigationQuery(
                        url,
                        Math.Max(0, start - (end - start)),
                        start
                    );
        }

        private string CreateNextNavigationQuery(string url, int start, int end, int recordsTotalCount)
        {
            return end >= recordsTotalCount
                    ? null
                    : CreateNavigationQuery(url, end, end + (end - start));
        }

        protected PaginatedRequestResult<T> CreatePaginatedRequestResult(int start, int end)
        {
            string urlReceived = Request.Path.Value;

            start = Math.Abs(start);
            end = Math.Abs(end);

            int startIndex = Math.Min(start, end);
            int endIndex = Math.Max(start, end);

            int recordsTotalCount = Repository
                .GetAll()
                .Count();

            IQueryable<T> records = Repository
                .GetAll()
                .OrderByDescending(r => r.CreatedOn)
                .Skip(startIndex)
                .Take(end - start);

            return new PaginatedRequestResult<T>(){
                data = records,
                previousQuery = CreatePreviousNavigationQuery(urlReceived, startIndex, endIndex),
                nextQuery = CreateNextNavigationQuery(urlReceived, startIndex, endIndex, recordsTotalCount)
            };
        }

        /// <summary>
        /// Method that returns all the record related to specified entity model.
        /// </summary>
        /// <returns>Json list of entity</returns>
        virtual protected IActionResult GetAllRecord(int? start = null, int? end = null)
        {
            try
            {
                IEnumerable<T> records = null;
                object requestResult = null;

                if (start != null && end != null && end != start)
                {
                    requestResult = CreatePaginatedRequestResult((int)start, (int)end);
                }
                else
                {
                    records = Repository
                        .GetAll()
                        .OrderBy(r => r.CreatedOn);
                    requestResult = records;
                }

                return CreateValidResponse(requestResult, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ResponseResult.InternalServerError(e.Message);
            }
        }

        /// <summary>
        /// Method that return a single record that match the id specified.
        /// </summary>
        /// <param name="id">Id of the document</param>
        /// <returns>Json document</returns>
        virtual protected IActionResult GetRecordById(int id)
        {
            try
            {
                T record = Repository.GetById(id);

                if (record is null)
                {
                    return ResponseResult.NoMatchingDocument(id);
                }

                return CreateValidResponse(record, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ResponseResult.InternalServerError(e.Message);
            }
        }

        /// <summary>
        /// Method that create a new record in the repository
        /// </summary>
        /// <param name="record">Record to create</param>
        /// <returns>Json result</returns>
        virtual protected IActionResult CreateRecord([FromBody] T record)
        {
            return CreateRecordWithFeedback(record).Result;
        }

        /// <summary>
        /// Method that return a single record that match the id specified.
        /// </summary>
        /// <param name="record">Record to create</param>
        /// <returns>ActionData</returns>
        virtual protected ActionData CreateRecordWithFeedback([FromBody] T record)
        {
            ActionData data = new ActionData();
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (ModelStateEntry modelState in ViewData.ModelState.Values)
                    {
                        foreach (ModelError error in modelState.Errors)
                        {
                            Console.WriteLine(error);
                        }
                    }
                    data.StatusCodes = StatusCodes.Status400BadRequest;
                    data.Result = ResponseResult.WrongData();
                    return data;
                }

                Repository.Create(record);
                Repository.SaveChanges();

                data.StatusCodes = StatusCodes.Status201Created;
                data.Result = CreateValidResponse(record, StatusCodes.Status201Created);
                return data;
            }
            catch (Exception e)
            {
                data.StatusCodes = StatusCodes.Status500InternalServerError;
                data.Result = ResponseResult.InternalServerError(e.Message);
                return data;
            }
        }

        /// <summary>
        /// Method that edit an existing record in the repository
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <param name="record">Updated record</param>
        /// <returns>Json result</returns>
        virtual protected IActionResult UpdateRecord(int id, [FromBody] T record)
        {
            try
            {
                if (id != record.Id)
                {
                    return ResponseResult.MismatchIdentifier(record.Id, id);
                }

                if (!ModelState.IsValid)
                {
                    return ResponseResult.WrongData();
                }

                if (!Repository.Contains(r => r.Id == id))
                {
                    return ResponseResult.NoMatchingDocument(id);
                }

                Repository.Update(record);
                Repository.SaveChanges();
                return CreateValidResponse(record, StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return ResponseResult.InternalServerError(e.Message);
            }
        }

        /// <summary>
        /// Method that delete a record in the repository
        /// </summary>
        /// <param name="id">Id of the record</param>
        /// <returns>Json result</returns>
        virtual protected IActionResult DeleteRecord(int id)
        {
            try
            {
                T record = Repository.GetById(id);
                if (record is null)
                {
                    return ResponseResult.NoMatchingDocument(id);
                }

                Repository.Delete(id);
                Repository.SaveChanges();
                return CreateValidResponse(record, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ResponseResult.InternalServerError(e.Message);
            }
        }

        /// <summary>
        /// Method that create a valid json response
        /// </summary>
        /// <param name="body">Body of the response</param>
        /// <param name="statusCode">Satus code of the response</param>
        /// <returns>Json result</returns>
        protected IActionResult CreateValidResponse(object body, int statusCode)
        {
            JsonResult parsedBody = ParseResponseInJson(body, statusCode);
            return Ok(parsedBody);
        }

        /// <summary>
        /// Method that parse a response in json
        /// </summary>
        /// <param name="data">Data to parse</param>
        /// <param name="statusCode">Status code to parse</param>
        /// <returns>Json response</returns>
        protected JsonResult ParseResponseInJson(object data, int statusCode)
        {
            JsonResult json = Json(data);
            json.ContentType = "application/json";
            json.StatusCode = statusCode;
            return json;
        }
    }

}
