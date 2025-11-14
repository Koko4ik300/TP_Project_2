using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace TP_Project
{
    public class HomeworkItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        private bool isDone;
        public bool IsDone
        {
            get => isDone;
            set
            {
                if (isDone != value)
                {
                    isDone = value;
                    OnPropertyChanged(nameof(IsDone));
                    SaveData.Save(new ObservableCollection<HomeworkItem>(HomePage.Items));
                }
            }
        }
        // тест!
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
