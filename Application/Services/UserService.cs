using Domain.WebApiModels;
using MySql.Data.MySqlClient;
using Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(string cn)
        {
            _userRepository = new UserRepository(cn);
        }


        /// <summary>
        /// Получить анекту по коду пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Profile? Get(Guid id)
        {
            var profile = _userRepository.GetProfile(id);
            return profile;
        }
    }
}
