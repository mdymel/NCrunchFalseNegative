using Microsoft.AspNetCore.Mvc;

namespace NCrunchIntTests
{
    public class ApiController : Controller
    {
        [Route("status")]
        [HttpPost]
        public string Status() => "OK";
    }
}