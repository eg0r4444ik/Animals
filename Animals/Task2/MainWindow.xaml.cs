using System.Windows;
using Task2.ViewModel;

namespace Task2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private AnimalsViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new AnimalsViewModel();
        DataContext = _viewModel;

        _viewModel.ShowVoiceMessage += ShowVoiceMessage;
    }

    private void AccelerateDog_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.AccelerateDog();
    }

    private void DogOnVoice(object sender, RoutedEventArgs e)
    {
        _viewModel.Dog.OnVocalize();
    }

    private void PantherOnVoice(object sender, RoutedEventArgs e)
    {
        _viewModel.Panther.OnVocalize();
    }

    private void PantherOnClimb(object sender, RoutedEventArgs e)
    {
        _viewModel.Panther.OnClimbTree();
    }

    private void ShowVoiceMessage(object sender, string message)
    {
        MessageBox.Show(message);
    }

    private void DecelerateDog_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.DecelerateDog();
    }

    private void AcceleratePanther_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.AcceleratePanther();
    }

    private void AccelerateTurtle_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.AccelerateTurtle();
    }

    private void DeceleratePanther_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.DeceleratePanther();
    }

    private void DecelerateTurtle_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.DecelerateTurtle();
    }
}
