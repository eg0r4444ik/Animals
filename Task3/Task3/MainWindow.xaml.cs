using System.Windows;

namespace Task3
{    
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {            
            InitializeComponent();
            DataContext = viewModel;
            ClassComboBox.SelectionChanged += updateListMetods;            
        }        

        private void updateListMetods(object sender, RoutedEventArgs e)
        {
            string selectedClass = (string)ClassComboBox.SelectedItem;
            MetodsComboBox.ItemsSource = viewModel.getListMetods(selectedClass);            
        }
        
        private void createClass(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedItem != null)
            {
                string selectedClass = (string)ClassComboBox.SelectedItem;
                viewModel.createClass(selectedClass);
            }else
            {
                MessageBox.Show("Выберите класс в первом выпадющем списке");
            }
        }

        private void selectMethod(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedItem != null && MetodsComboBox.SelectedItem != null)
            {
                string selectedMethode = (string)MetodsComboBox.SelectedItem;
                viewModel.methodFromClass(selectedMethode);
            }
            else
            {
                MessageBox.Show("Выберите метод во втором выпадющем списке");
            }
        }

        private void checkClass(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedItem != null)
            {
                string selectedClass = (string)ClassComboBox.SelectedItem;
                viewModel.checkClass();
            }
            else
            {
                MessageBox.Show("Выберите класс в первом выпадющем списке");
            }
        }
    }
}