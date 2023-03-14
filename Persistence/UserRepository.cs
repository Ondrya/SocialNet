using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.WebApiModels;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UserRepository : IUserRepository
    {
        private string _connectionString;
        
        public UserRepository(string conn)
        {
            _connectionString = conn;
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public User? Get(Guid id)
        {
            using (var db = new MySqlConnection(_connectionString))
            {
                var user = db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).SingleOrDefault();
                return user;
            }
        }

        public Profile? GetProfile(Guid id)
        {
            using (var db = new MySqlConnection(_connectionString))
            {
                var profile = db.Query<Profile>(SqlQuery.GetProfileById, new { id }).SingleOrDefault();
                return profile;
            }
        }
    }


    public class SqlQuery
    {
        public static string GetProfileById => @"
SELECT 
	u.Id as id
    , u.NameFirst as first_name
    , u.NameLast  as second_name
    , u.DateOfBirth as birthdate
    , DATE_FORMAT(FROM_DAYS(DATEDIFF(NOW(),u.DateOfBirth)), '%Y') + 0 AS age
	, c.Name as City
    , u.Biography
FROM 
	Users as u 
    left join Cities as c on u.CityId = c.Id
WHERE u.Id = @id ;
";
    }
}
