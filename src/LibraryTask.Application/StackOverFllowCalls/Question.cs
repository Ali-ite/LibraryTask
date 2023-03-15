using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace LibraryTask.StackOverFllowCalls
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int AnswerCount { get; set; }
        public int ViewCount { get; set; }
    }
    
}