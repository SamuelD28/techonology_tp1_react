using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technology_Tp1_React.General
{
    public static class ErrorResponse
    {
        private static IActionResult CreateErrorResponse(string errorMessage, int statusCode)
        {
            JsonResult body = new JsonResult(new { error = errorMessage });
            body.ContentType = "application/json";
            body.StatusCode = statusCode;

            ObjectResult response = new ObjectResult(body);
            response.StatusCode = statusCode;
            return response;
        }

        public static IActionResult MismatchIdentifier(int formId, int requestId)
        {
            return CreateErrorResponse(
                        $"Mismatch identifier passed. form id : {formId} request id : {requestId}",
                        StatusCodes.Status409Conflict
                    );
        }

        public static IActionResult WrongData()
        {
            return CreateErrorResponse(
                        "Can't create document with specified data",
                        StatusCodes.Status400BadRequest
                    );
        }

        public static IActionResult InternalServerError(string error)
        {
            return CreateErrorResponse(
                    error,
                    StatusCodes.Status500InternalServerError
                );
        }

        public static IActionResult NoMatchingDocument(int documentId)
        {
            return CreateErrorResponse(
                        $"No matching document for id : {documentId}",
                        StatusCodes.Status404NotFound
                    );
        }
    }
}
