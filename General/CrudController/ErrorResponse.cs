using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technology_Tp1_React.General.CrudController
{
    /// <summary>
    /// Class that create error response to the client
    /// </summary>
    public static class ErrorResponse
    {
        /// <summary>
        /// Method that create an error response based on its parameters
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="statusCode">Error Status code</param>
        /// <returns>Json Error response</returns>
        private static IActionResult CreateErrorResponse(string errorMessage, int statusCode, object data = null)
        {
            JsonResult body = new JsonResult(new { error = errorMessage, body = data ?? "" });
            body.ContentType = "application/json";
            body.StatusCode = statusCode;

            ObjectResult response = new ObjectResult(body);
            response.StatusCode = statusCode;
            return response;
        }

        /// <summary>
        /// Method that create a mismatch identifier response
        /// </summary>
        /// <param name="formId">Form identifier</param>
        /// <param name="requestId">Request identifier</param>
        /// <returns>Json Error response</returns>
        public static IActionResult MismatchIdentifier(int formId, int requestId)
        {
            return CreateErrorResponse(
                        $"Mismatch identifier passed. form id : {formId} request id : {requestId}",
                        StatusCodes.Status409Conflict
                    );
        }

        /// <summary>
        /// Method that create a wrong data error response
        /// </summary>
        /// <returns>Json Error response</returns>
        public static IActionResult WrongData()
        {
            return CreateErrorResponse(
                        "Can't create document with specified data",
                        StatusCodes.Status400BadRequest
                    );
        }

		/// <summary>
		/// Method that create a wrong data error response
		/// </summary>
		/// <returns>Json Error response</returns>
		public static IActionResult WrongData(object data)
		{
			return CreateErrorResponse(
						"Can't create document with specified data",
						StatusCodes.Status400BadRequest,
						data
					);
		}

		/// <summary>
		/// Method that create an internal server error
		/// </summary>
		/// <param name="error">Error message</param>
		/// <returns>Json Error response</returns>
		public static IActionResult InternalServerError(string error)
        {
            return CreateErrorResponse(
                    error,
                    StatusCodes.Status500InternalServerError
                );
        }

        /// <summary>
        /// Method that return a no document match error
        /// </summary>
        /// <param name="documentId">Document identifier</param>
        /// <returns>Json Error response</returns>
        public static IActionResult NoMatchingDocument(int documentId)
        {
            return CreateErrorResponse(
                        $"No matching document for id : {documentId}",
                        StatusCodes.Status404NotFound
                    );
        }
    }
}
