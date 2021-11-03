using System;
using System.Text.RegularExpressions;
using Plumsail.DAL;

namespace Plumsail.BLL
{
    /// <summary>
    /// Класс ViewModel контакта, хранящий информацию о человеке 
    /// </summary>
    public class ContactVM
    {
        private int? id;
        private string name;
        private string surname;
        private DateTime birthday;
        private string phone;
        private string email;
        private SexType? sex;

        /// <summary>
        /// Id.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имя не было заполнено!");
                }

                name = value;
            }
        }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname
        {
            get => surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Фамилия не была заполнена!");
                }

                surname = value;
            }
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthday
        {
            get => birthday;
            set
            {
                if (!DateTime.TryParse(value.ToString(), out DateTime result))
                {
                    throw new ArgumentException("Дата рождения имеет неверный формат");
                }

                if (value > DateTime.Now.Date)
                {
                    throw new ArgumentException("Дата рождения не может быть больше настоящего времени");
                }

                birthday = value;
            }
        }

        /// <summary>
        /// Телефонный номер.
        /// </summary>
        public string Phone
        {
            get => phone;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Телефон не был не было вписан!");
                }

                if (!Regex.IsMatch(value, @"[0-9]{11}", RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException("Номер телефона имеет неверный формат!");
                }

                phone = value;
            }
        }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email
        {
            get => email;
            set
            {
                if (!Regex.IsMatch(value,
                    @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})",
                    RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException("Email имеет неверный формат!");
                }

                email = value;
            }
        }

        /// <summary>
        /// Пол человека.
        /// </summary>
        public SexType Sex
        {
            get => sex.GetValueOrDefault();
            set
            {
                if (Enum.TryParse(value.ToString(), out SexType result))
                {
                    throw new ArgumentException("Пол имеет неверный формат");
                }
            } 
        }

        /// <summary>
        /// Конвертировать из ViewModel в Contact.
        /// </summary>
        /// <param name="contact">Объект класса ContactVM.</param>
        /// <returns>Объект класса Contact.</returns>
        public Contact FromViewToModel()
        {
            return new Contact
            {
                Id = Id.GetValueOrDefault(),
                Name = Name,
                Surname = Surname,
                Birthday = Birthday,
                Phone = Phone,
                Email = Email,
                Sex = sex.ToString(),
            };
        }

        /// <summary>
        /// Конвертировать из Contact в ViewModel.
        /// </summary>
        /// <param name="contact">Объект класса Contact.</param>
        /// <returns>Объект класса ContactVM.</returns>
        public static ContactVM FromModelToView(Contact contact)
        {
            return new ContactVM
            {
                Id = contact.Id,
                Name = contact.Name,
                Surname = contact.Surname,
                Birthday = contact.Birthday,
                Phone = contact.Phone,
                Email = contact.Email,
                Sex = Enum.Parse<SexType>(contact.Sex),
            };
        }
    }
}