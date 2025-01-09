using ControleDeContactos.Models;
using ControleDeContactos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContactos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase, IContactController
    {
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<ContactController> _logger;
        public ContactController(IContactRepository contactRepository, ILogger<ContactController> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<ContactModel>> Add([FromBody] ContactModel contact)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                ContactModel contactModel  = await _contactRepository.Add(contact);
                return Ok(contactModel);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured while adding contact.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactModel>> Delete(int id)
        {
            try
            {
                bool remove = await _contactRepository.Delete(id);
                if (!remove) return NotFound($"Contact with ID {id} not found.");
                return NoContent();
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while deleting contact with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ContactModel>>> ListAll()
        {
            try
            {
                List<ContactModel> contacts = await _contactRepository.ListAll();
                if(contacts == null || contacts.Count == 0) return NotFound("No contacts found.");
                return Ok(contacts);
            }
            catch(Exception error)
            {
                _logger.LogError(error, "An error occured while retrieving contacts.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactModel>> ListByID(int id)
        {
            try
            {
                ContactModel contactID = await _contactRepository.ListByID(id);
                if (contactID == null) return NotFound($"Contact with ID {id} not found.");
                return Ok(contactID);
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while retrieving contact with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
        [HttpPut]
        public async Task<ActionResult<ContactModel>> Update([FromBody] ContactModel contact, int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var existingContact = await _contactRepository.ListByID(id);
                if (existingContact == null) return NotFound($"Contact with ID {id} not found.");
                contact.Id = id;
                ContactModel contactModel = await _contactRepository.Update(contact, id);
                return Ok(contactModel);
            }
            catch(Exception error)
            {
                _logger.LogError(error, $"An error occured while updating contact with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}