using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Technology_Tp1_React.General.CrudController
{
    public struct ActionData
    {
        public IActionResult Result { get; set; }
        public int StatusCodes { get; set; }
    }
}