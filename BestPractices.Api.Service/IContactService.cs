using BestPractices.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.Api.Service
{
    public interface IContactService
    {
        public  Task<ContactDVO> GetContactById(int id);
    }
}
