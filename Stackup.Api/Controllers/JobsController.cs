using Microsoft.AspNetCore.Mvc;

namespace Stackup.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : Controller
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Postal Code Controller
        /// </summary>
        /// <param name="commandDispatcher"></param>
        public JobsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(Name = "StartJob")]
        [Route("start")]
        public IActionResult StartJob()
        {
            _configuration["Status"] = "Processing";
            DateTime currentTime = DateTime.UtcNow;
            DelayWithCallback(10000, () =>
            {
                _configuration["Status"] = "Completed";
            });


            return Ok($"Current Time: {currentTime}");
        }

        public static async Task DelayWithCallback(int millisecondsDelay, Action callback)
        {
            await Task.Delay(millisecondsDelay);
            callback?.Invoke();
        }

        [HttpGet(Name = "JobStatus")]
        [Route("status")]
        public async Task<IActionResult> JobStatus()
        {
            var status = _configuration.GetValue<string>("Status");

            return Ok(status);
        }
    }
}
