using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace NotesApp
{
    class AddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        INotesModel _notesModel;
        Note _note;

        public AddViewModel()
        {
            _notesModel = new JsonNotes();
            _note = new Note();
        }

        public ICommand AddNoteButton
        {
            get
            {
                return new ButtonCommand(new Action(()=>
                {
                    _note.Id = 1;
                    _notesModel.AddNote(_note);
                    MessageBox.Show("Добавлено!");
                }));
            }
        }

        public Note AddNote
        {
            get { return _note; }
            set
            {
                _note = value;
                Notify("AddNote");            
            }
        }
    }
}
