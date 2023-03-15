using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static LibraryTask.Enums.Enum;

namespace LibraryTask.Domain.Attachments
{
    // Attachment model
    public class Attachment : FullAuditedEntity<long>
    {
        [StringLength(500)]
        public string Name { get; set; }

        public AttachmentType Type { get; set; }

        /// <summary>
        /// Path of the attachment file relative to configured dir
        /// </summary>
        [Required]
        [StringLength(1000)]
        public string RelativePath { get; set; }

        public long? RefId { get; set; }

        public AttachmentRefType RefType { get; set; }

        public static bool IsValidAttachmentRefType(byte type)
        {
            return Enum.IsDefined(typeof(AttachmentRefType), type);
        }
    }
  

}



