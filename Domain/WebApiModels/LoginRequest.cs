using System;

namespace Domain.WebApiModels
{
    public class LoginRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }


        public bool IsValid()
        {
            return !(Guid.Empty.Equals(Id) || string.IsNullOrWhiteSpace(Password));
        }
    }


    public class LoginResponse
    {
        public Guid Token { get; set; }
    }
}
