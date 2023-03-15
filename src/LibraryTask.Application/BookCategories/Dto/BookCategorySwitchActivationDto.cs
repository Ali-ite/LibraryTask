using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryTask.BookCategories.Dto
{
    /// <summary>
    /// Blog Category Switch Activation Dto
    /// </summary>
    public class BookCategorySwitchActivationDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }
    }
}
