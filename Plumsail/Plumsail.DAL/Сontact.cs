using System;
using System.ComponentModel.DataAnnotations;

namespace Plumsail.DAL
{
    /// <summary>
    /// Класс формы.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Телефонный номер.
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public string Sex { get; set; }
    }
}
