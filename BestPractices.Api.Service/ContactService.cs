using AutoMapper;
using BestPractices.API.Data;
using BestPractices.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.Api.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactService(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ContactDVO> GetContactById(int id)
        {
            //Veritabanından kaydın getirilmesi

            Contact dbContext = getDummyContact();
            ContactDVO resultContext = _mapper.Map<ContactDVO>(dbContext);

            var client = _httpClientFactory.CreateClient("garantiApi");
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("garanti.com");
            //client.DefaultRequestHeaders.Add("Authorization", "Bearer 21212");
            //String get =await client.GetStringAsync("/api/getPayment");

            //client.Dispose();

            return resultContext;

            //return new ContactDVO()
            //{
            //    Id = dbContext.Id,
            //    FullName = $"{dbContext.FirstName} {dbContext.LastName}"
            //};

        }

        private Contact getDummyContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Yasin",
                LastName = "Çoban"
            };
        }
    }
}
