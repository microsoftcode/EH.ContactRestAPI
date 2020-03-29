using ContactApi.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactRestAPI.Data

{
    /// <summary>
    /// Represents a Contact information
    /// </summary>
    public class Contact :IEntity
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }   

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public int Status { get; set; }
    }
}
