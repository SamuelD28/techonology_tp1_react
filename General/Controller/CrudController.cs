using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Technology_Tp1_React.General
{
    /// <summary>
    /// Generic controller class that handles the interaction between a IEntity model
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

        [HttpGet]
        virtual public IActionResult Get()
        {
            try
            {
                IEnumerable<T> deliveryMen = Repository.GetAll();
                return CreateValidResponse(deliveryMen, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }
        }

        [HttpGet("{id}")]
        virtual public IActionResult Get(int id)
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

        [HttpPost]
        virtual public IActionResult Create([FromBody] T record)
        {
            try
            {
                if (!ModelState.IsValid)
                {
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

        [HttpPut("{id}")]
        virtual public IActionResult Edit(int id, [FromBody] T record)
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

                if (Repository.GetById(id) == null)
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

        // DELETE: DeliveryMen/:id
        [HttpDelete("{id}")]
        virtual public IActionResult Delete(int id)
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

        protected IActionResult CreateValidResponse(object data, int statusCode)
        {
            JsonResult body = ParseResponseInJson(data, statusCode);
            return Ok(body);
        }

        protected JsonResult ParseResponseInJson(object data, int statusCode)
        {
            JsonResult json = Json(data);
            json.ContentType = "application/json";
            json.StatusCode = statusCode;
            return json;
        }
    }
}
