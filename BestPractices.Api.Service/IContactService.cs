using BestPractices.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestPractices.Api.Service
{
    public interface IContactService
    {
        public ContactDVO GetContactById(int id);
    }
}
