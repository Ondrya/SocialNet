using Domain.Models;
using Domain.WebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);
        //void Delete(int id);
        User Get(Guid id);
        Profile GetProfile(Guid id);
        //List<User> GetUsers();
        //void Update(User user);
    }
}
