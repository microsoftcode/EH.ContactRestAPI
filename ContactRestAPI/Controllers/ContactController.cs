using ContactRestAPI.Data;
using ContactRestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace ContactRestAPI.Controllers
{
    /// <summary>
    /// contacts endpoint of contacts API.
    /// </summary>
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<ContactController> _logger;

        /// <summary>
        /// Creates a new instance of <see cref="ContactController"/> with dependencies injected.
        /// </summary>
        /// <param name="contactRepository">A repository for managing the contact.</param>
        /// <param name="logger">Logger implementation.</param>
        public ContactController(IContactRepository contactRepository, ILogger<ContactController> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }

        /// <summary>
        /// Delete the contact with the given id.
        /// </summary>
        /// <param name="id">Id of the contact to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogDebug($"Deleting contact with id {id}");

            if (string.IsNullOrWhiteSpace(id.ToString()))
                return NotFound();

            var contact = await _contactRepository.GetById(id);
            if (contact == null)
                return NotFound();

            await _contactRepository.Delete(id);

            return Ok("Deleted successfully");
        }

        /// <summary>
        /// Get all contacts.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IQueryable<Contact>))]
        public  IActionResult GetAll()
        {
            _logger.LogDebug("Getting all contacts");

            var contacts =  _contactRepository.GetAll();

            return Ok(contacts);
        }

        /// <summary>
        /// Get a single contact by id.
        /// </summary>
        /// <param name="id">Id of the contact to retrieve.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogDebug($"Getting a contact with id {id}");

            if (string.IsNullOrWhiteSpace(id.ToString()))
                return NotFound();

            var contact = await _contactRepository.GetById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        /// <summary>
        /// Create a new contact from the supplied data.
        /// </summary>
        /// <param name="model">Data to create the contact from.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Contact))]
        public async Task<IActionResult> Post(ContactInput model)
        {
            _logger.LogDebug($"Creating a new contact with Email \"{model.Email}\"");

            var contact = new Contact();
            model.MapToContact(contact);

            await _contactRepository.Create(contact);

           return CreatedAtAction(nameof(GetById), "contact", new { id = contact.Id }, contact);

        }

        /// <summary>
        /// Updates the contact with the given id.
        /// </summary>
        /// <param name="id">Id of the contact to update.</param>
        /// <param name="model">Data to update the contact from.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, ContactInput model)
        {
            _logger.LogDebug($"Updating a contact with id {id}");

            var contact = await _contactRepository.GetById(id);

            if (contact == null)
                return NotFound();

            model.MapToContact(contact);

            await _contactRepository.Update(id , contact);

            return Ok(contact);
        }
    }
}
