using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    /// <summary>
    /// Интересы пользователей
    /// </summary>
    public class Interest
    {
        /// <summary>
        /// Идентификатор интереса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название интереса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Активность
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
