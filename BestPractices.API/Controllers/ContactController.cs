using BestPractices.Api.Service;
using BestPractices.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IContactService _contactService;
        public ContactController(IConfiguration configuration, IContactService contactService)
        {
            _configuration = configuration;
            _contactService = contactService;
        }

        [HttpGet]
        public string GetString()
        {

            return _configuration["ENV"].ToString();
        }
        [HttpGet("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ContactDVO> GetContactById(int id)
        {
            return await _contactService.GetContactById(id);
        }
        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contact)
        {


            //Create Contact on DB

            return contact;
        }
    }
}
