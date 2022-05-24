using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace NotesApp
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        List<Note> _notes;
        INotesModel notesModel;
        Note _note;

        public MainViewModel()
        {
            notesModel = new JsonNotes();
            if (notesModel.GetAllNotes() != null)
                Notes = new List<Note>(notesModel.GetAllNotes());
            else
                Notes = new List<Note>();
        }

        public ICommand NewNote
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    AddNote addNote = new AddNote();
                    addNote.ShowDialog();
                    Notes = new List<Note>(notesModel.GetAllNotes());
                }));
            }
        }

        public ICommand DeleteNote
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    if (_note != null)  //Если мы выделили item
                    {
                        //Результат нажатия на кнопки присваивается в result
                        MessageBoxResult result = MessageBox.Show("Действительно удалить запись?",
                            "Удаление записи" + _note.Header,
                             MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                            notesModel.DeleteNote(_note);
                        Notes = new List<Note>(notesModel.GetAllNotes());
                    }
                }));
            }
        }

        public ICommand UpdateNote
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    if (_note != null)  
                    {
                        UpdateViewModel.Id = _note.Id;
                        Update form = new Update();
                        form.ShowDialog();
                        Notes = new List<Note>(notesModel.GetAllNotes());
                    }
                }));
            }
        }

        public List<Note> Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                Notify("Notes");
            }
        }
        public Note SelectedNote
        {
            get { return _note; }
            set
            {
                _note = value;
                Notify("SelectedNote");
            }
        }
    }
}
