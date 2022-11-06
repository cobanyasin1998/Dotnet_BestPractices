using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContactController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string GetString()
        {

            return _configuration["ENV"].ToString();
        }
    }
}
