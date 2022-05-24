using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; //Установленная библиотека с NuGet
using System.IO;

namespace NotesApp
{
    class JsonNotes : INotesModel
    {
        List<Note> _notes;

        private void SaveFile(string filename)
        {
            //Конвертируем список заметок в json-формат и записываем в файл
            string json = JsonConvert.SerializeObject(_notes);
            //Когда сохраняем файл, сохраняем стирая старый файл
            FileStream fileStream = new FileStream(filename, FileMode.Truncate);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.Write(json);
            writer.Flush();     //Очистка потока
            writer.Close();
            fileStream.Close();
        }
        public JsonNotes()
        {
            GetAllNotes();
            /*_notes = new List<Note>()
            {
                new Note()
                {
                    Id = 1,
                    Header = "Купить молоко",
                    Text = "Нужно сходить в магазин за молоком!\nСрочно!",
                    ImageUri = "C:\\Users\\Admin\\Figures\\bird.png",
                    DeadLine = DateTime.Now
                },

                new Note()
                {
                    Id = 2,
                    Header = "Проверить ДЗ",
                    Text = "Не забывай проверять ДЗ!",
                    ImageUri = "C:\\Users\\Admin\\Figures\\bird.png",
                    DeadLine = DateTime.Now
                },

                new Note()
                {
                    Id = 3,
                    Header = "Сходить на учёбу",
                    Text = "К 9:30 подойти в универ",
                    ImageUri = "C:\\Users\\Admin\\Figures\\bird.png",
                    DeadLine = DateTime.Now
                }
            };*/

            //SaveFile("Notes.txt");
        }
        public void AddNote(Note note)
        {
            if (_notes == null)
                _notes = new List<Note>();
            _notes.Add(note);
            SaveFile("Notes.txt");
        }

        public void DeleteNote(Note note)
        {
            _notes.Remove(note);
            SaveFile("Notes.txt");
        }

        public List<Note> GetActualNotes()
        {
            List<Note> result = new List<Note>();
            foreach(Note note in _notes)
            {
                if(note.DeadLine > DateTime.Now)
                {
                    result.Add(note);
                }
            }
            return result;
        }

        public List<Note> GetAllNotes()
        {
            //Читаем с файла
            FileStream fileStream = new FileStream("Notes.txt", FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            string json = streamReader.ReadToEnd();
            _notes = JsonConvert.DeserializeObject<List<Note>>(json);
            streamReader.Close();
            fileStream.Close();
            return _notes;
        }

        public Note GetNote(int id)
        {
            return _notes.Find((note) => note.Id == id);
        }

        public void UpdateNote(Note note, Note result)
        {
            Note findNote = _notes.Find((n) => n.Id == note.Id);
            findNote.Header = result.Header;
            findNote.Text = result.Text;
            findNote.ImageUri = result.ImageUri;
            findNote.DeadLine = result.DeadLine;
            SaveFile("Notes.txt");
        }
    }
}
