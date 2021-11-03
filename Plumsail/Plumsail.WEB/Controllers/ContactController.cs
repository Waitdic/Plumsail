using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Plumsail.BLL;

namespace Plumsail.WEB.Controllers
{
    /// <summary>
    /// Контроллер работы с контактами.
    /// </summary>
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : Controller
    {
        private readonly IContactManager _contactManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="contactManager">Менеджер контактов.</param>
        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        /// <summary>Получить все контакты все контакты.</summary>
        /// <returns>Список контактов.</returns>
        [HttpGet("")]
        public ActionResult<List<ContactVM>> GetContacts()
        {
            return _contactManager.GetContacts();
        }

        /// <summary>Получить контакт.</summary>
        /// <param name="id">Id контакта.</param>
        /// <returns>Контакт.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<ContactVM> GetContact(int id)
        {
            return _contactManager.GetContactById(id);
        }

        /// <summary>Добавить контакт.</summary>
        /// <param name="contact">Контакт.</param>
        [HttpPost]
        public ActionResult<List<ContactVM>> AddContact(ContactVM contact)
        {
            _contactManager.AddContact(contact);
            return Ok(_contactManager.GetContacts());
        }
    
        /// <summary>Добавить контакт.</summary>
        /// <param name="contact">Контакт</param>
        [HttpPut]
        public IActionResult EditContact(ContactVM contact)
        {
            _contactManager.EditContact(contact);
            return Ok();
        }

        /// <summary>Добавить контакт.</summary>
        /// <param name="id">Id контанта.</param>
        [HttpDelete("{id:int}")]
        public IActionResult DeleteContact(int id)
        {
            _contactManager.DeleteContact(id);
            return Ok();
        }
    }
}
