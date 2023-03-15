
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryTask.Enums
{
    public class Enum
    {



        public enum AttachmentRefType : byte
        {
            Book = 1,

        }
        public enum AttachmentType : byte
        {
            PDF = 1,
            WORD = 2,
            JPEG = 3,
            PNG = 4,
            JPG = 5,
            MP4 = 6,
            MP3 = 7,
        }
        public enum ImageType : byte
        {
            JPEG = 1,
            PNG = 2,
            JPG = 3
        }





    }
}

