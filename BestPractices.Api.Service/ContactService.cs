using AutoMapper;
using BestPractices.API.Data;
using BestPractices.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestPractices.Api.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        public ContactService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ContactDVO GetContactById(int id)
        {
            //Veritabanından kaydın getirilmesi

            Contact dbContext = getDummyContact();
            ContactDVO resultContext = _mapper.Map<ContactDVO>(dbContext);


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
