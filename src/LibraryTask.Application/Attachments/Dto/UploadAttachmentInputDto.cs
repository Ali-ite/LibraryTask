using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using LibraryTask.Domain.Attachments;

namespace LibraryTask.Attachments.Dto
{
    /// <summary>
    /// UploadAttachmentInputDto
    /// </summary>
    [AutoMapTo(typeof(Attachment))]
    public class UploadAttachmentInputDto : ICustomValidate
    {
        /// <summary>
        /// 1 Book = 1,
        
        /// </summary>
        public byte RefType { get; set; }

        /// <summary>
        /// Accepted File Types: 1- Pdf, 2- Word, 3- Jpeg, 4- Png, 5- Jpg
        /// </summary>
        [Required(ErrorMessage = "Required")]
        public IFormFile File { get; set; }

        /// <summary>
        /// AddValidationErrors
        /// </summary>
        /// <param name="context"></param>
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (!Attachment.IsValidAttachmentRefType(RefType))
            {
                // context.Results.Add(new ValidationResult(L("InvalidAttachmentRefType"));
            }
        }
    }
}