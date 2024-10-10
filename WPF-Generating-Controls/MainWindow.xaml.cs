using System.Windows;

namespace WPF_Generating_Controls;
public partial class MainWindow : Window
{
  public MainWindow() => InitializeComponent();

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
    InitCBX();
    InitCHBX();
  }

  private void InitCHBX()
  {
    CHBXClasses.Children.Clear();
    List<string> classes = new List<string>();
    foreach (var student in Configuration.Students)
    {
      if (!classes.Contains(student.Clazz))
      {
        classes.Add(student.Clazz);
      }
    }
  }

  private void InitCBX()
  {
    CBXNames.Items.Clear();
    foreach (var item in Configuration.Students)
    {
      CBXNames.Items.Add(item);
    }
    CBXNames.SelectedIndex = 0;
    LBLSelected.Content = $"{CBXNames.SelectedItem} selected";
    CBXNames.SelectionChanged += (s, e) => LBLSelected.Content = $"{CBXNames.SelectedItem} selected";
  }
}
