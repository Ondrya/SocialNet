namespace Domain.Models
{
    /// <summary>
    /// Пол человека
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Код пола
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название пола
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
