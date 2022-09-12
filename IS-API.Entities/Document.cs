using System;

namespace IS_API.Entities
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int Fk_UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
