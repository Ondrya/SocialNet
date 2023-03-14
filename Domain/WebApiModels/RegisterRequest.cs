using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WebApiModels
{
    public class RegisterRequest
    {
    }

    public class RegisterResponse : Profile
    {
        public string Password { get; set; }
    }

    public class Profile
    {
        public Guid id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public int age { get; set; }
        public DateTime birthdate { get; set; }
        public string biography { get; set; }
        public string city { get; set; }
    }
}
