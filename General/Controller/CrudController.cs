using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Technology_Tp1_React.General
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

        /// <summary>
        /// Method that returns all the record related to specified entity model.
        /// </summary>
        /// <returns>Json list of entity</returns>
        virtual protected IActionResult GetAllRecord(int? start = null, int? end = null)
        {
            try
            {
                IEnumerable<T> deliveryMen = null;
                object requestResult = null;

                if (start != null && end != null)
                {
                    deliveryMen = Repository
                        .GetAll()
                        .Skip((int)start)
                        .Take((int)end - (int)start);

                    requestResult = new {
                        data = deliveryMen,
                        next = $"{Request.Path.Value}?start={end}&end={(end - start) + end}"
                    };
                }
                else
                {
                    deliveryMen = Repository.GetAll();
                    requestResult = deliveryMen;
                }

                return CreateValidResponse(requestResult, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
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
                    return ErrorResponse.NoMatchingDocument(id);
                }

                return CreateValidResponse(record, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }
        }

        /// <summary>
        /// Method that create a new record in the repository
        /// </summary>
        /// <param name="record">Record to create</param>
        /// <returns>Json result</returns>
        virtual protected IActionResult CreateRecord([FromBody] T record)
        {
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
                    return ErrorResponse.WrongData();
                }

                Repository.Create(record);
                Repository.SaveChanges();

                return CreateValidResponse(record, StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
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
                    return ErrorResponse.MismatchIdentifier(record.Id, id);
                }

                if (!ModelState.IsValid)
                {
                    return ErrorResponse.WrongData();
                }

                if (!Repository.Contains(r => r.Id == id))
                {
                    return ErrorResponse.NoMatchingDocument(id);
                }

                Repository.Update(record);
                Repository.SaveChanges();
                return CreateValidResponse(record, StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
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
                    return ErrorResponse.NoMatchingDocument(id);
                }

                Repository.Delete(id);
                Repository.SaveChanges();
                return CreateValidResponse(record, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
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
