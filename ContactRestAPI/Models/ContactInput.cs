using ContactRestAPI.Data;
using ContactApi.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactRestAPI.Models
{
    /// <summary>
    /// Represents a single Contact to be saved.
    /// </summary>
    public class ContactInput
    {

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        /// [Required]
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumber
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        [Required]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Copy data to <see cref="Contact"/> instance.
        /// </summary>
        public void MapToContact(Contact contact)
        {
            contact.FirstName = FirstName;
            contact.LastName = LastName;
            contact.PhoneNumber = PhoneNumber;
            contact.LastName = LastName;
            contact.Status = (int)Status;
            contact.Email = Email;      
        }
    }
}
