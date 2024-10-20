using Microsoft.AspNetCore.Mvc;

namespace TestTimeConsumingOperationWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestLongOperationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(5000);
            return new ContentResult
            {
                Content = "Web API Long Operation completed",
            };
        }
    }
}
