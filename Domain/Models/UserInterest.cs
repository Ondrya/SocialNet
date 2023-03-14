using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    /// <summary>
    /// Интерес конкретного пользователя
    /// </summary>
    public class UserInterest
    {
        /// <summary>
        /// Идентификатор связки
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        virtual public User User { get; set; }
        /// <summary>
        /// Интерес
        /// </summary>
        virtual public Interest Interest { get; set; }
    }
}
