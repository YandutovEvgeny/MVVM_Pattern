using System;

namespace NotesApp
{
    class Note
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public string ImageUri { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
