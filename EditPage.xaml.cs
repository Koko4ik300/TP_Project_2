using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace TP_Project
{

    public partial class EditPage : Page
    {
        private HomeworkItem _originalItem;

        public EditPage(HomeworkItem hi2)
        {
            InitializeComponent();
            _originalItem = hi2;
            SubjectTextBox2.Text = _originalItem.Title;
            HomeworkTextBox2.Text = _originalItem.Description;
            DatePicker2.SelectedDate = _originalItem.DueDate;
            
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(SubjectTextBox2.Text) && !string.IsNullOrEmpty(HomeworkTextBox2.Text))
            {
                HomePage.Items.Remove(_originalItem);
                HomePage.Items.Add(new HomeworkItem
                {
                    Title = SubjectTextBox2.Text,
                    Description = HomeworkTextBox2.Text,
                    IsDone = false,
                    DueDate = DatePicker2.SelectedDate ?? DateTime.Now,
                });
                SaveData.Save(HomePage.Items);
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
