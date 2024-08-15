using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {

        [HttpGet("throw")]
        public int ThrowException()
        {
            var b = 10;
            var c = 0;
            var a = 0;
            try
            {               
                a = b / c;
            }
            catch(Exception ex)
            {
                throw new Exception("This is test exception");

            }
            return a;
        }
    }
}
