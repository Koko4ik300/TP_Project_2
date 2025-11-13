

using System.ComponentModel;

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
