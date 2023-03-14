using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string NameFirst { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string NameLast { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Интересы
        /// </summary>
        public string Biography { get; set; }

        /// <summary>
        /// Город пользователя
        /// </summary>
        public virtual City City { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }


        /// <summary>
        /// Вычислить возраст по дате рождения
        /// </summary>
        /// <returns></returns>
        public int GetAge()
        {
            int age = 0;
            age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
