using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.IO;



namespace TP_Project
{
    public partial class HomePage : Page
    {
        public HomePage Instance;
        public static ObservableCollection<HomeworkItem> Items = new ObservableCollection<HomeworkItem>();
        public HomePage()
        {
            InitializeComponent();
            Instance = this;

            foreach(var item in SaveData.Load())
                Items.Add(item);
            
            HomeworkList.ItemsSource = Items;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddHomeworkPage());
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            string text = SearchBox.Text;

            List<HomeworkItem> filtered = new List<HomeworkItem>();
            if(string.IsNullOrEmpty(text))
            {
                HomeworkList.ItemsSource = Items;
            }

            foreach (HomeworkItem item in Items)
            {
                if(item.Title.ToLower().Contains(text.ToLower()))
                {
                    filtered.Add(item);
                }
            }
            HomeworkList.ItemsSource = filtered;
        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FilterDatePicker.SelectedDate == null)
            {
                HomeworkList.ItemsSource = Items;
                return;
            }

            List<HomeworkItem> filtered = new List<HomeworkItem>();

            foreach(HomeworkItem item in Items)
            {
                if(item.DueDate <= FilterDatePicker.SelectedDate.Value)
                {
                    filtered.Add(item);
                }
            }
            HomeworkList.ItemsSource = filtered;
        }

        private void HomeworkList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListBox lb = sender as ListBox;
            HomeworkItem hi = HomeworkList.SelectedItem as HomeworkItem;
            if (lb != null && lb.SelectedItem != null)
            {
                NavigationService.Navigate(new EditPage(hi));
            }
        }
    }
}
