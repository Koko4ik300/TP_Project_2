using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace TP_Project
{
    public partial class AddHomeworkPage : Page
    {

        public AddHomeworkPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(SubjectTextBox.Text) && !string.IsNullOrEmpty(HomeworkTextBox.Text))
            {
                HomePage.Items.Add(new HomeworkItem
                {
                    Title = SubjectTextBox.Text,
                    Description = HomeworkTextBox.Text,
                    IsDone = false,
                    DueDate = DatePicker.SelectedDate ?? DateTime.Now,
                });

                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
