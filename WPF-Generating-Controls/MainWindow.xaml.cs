using System.Windows;
using System.Windows.Controls;

namespace WPF_Generating_Controls;
public partial class MainWindow : Window
{
  public MainWindow() => InitializeComponent();

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
    InitCBX();
    InitCHBX();
    InitBTN();
  }

  private void InitBTN()
  {
    BtnClasses.Children.Clear();
    List<string> classes = new List<string>();
    foreach (var student in Configuration.Students)
    {
      if (!classes.Contains(student.Clazz))
      {
        classes.Add(student.Clazz);
      }
    }
    foreach (var clazz in classes)
    {
      BtnClasses.Children.Add(new Button()
      {
        Content = clazz,
        Margin = new Thickness(10, 10, 10, 10)
      }
      );
    };
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
    foreach (var clazz in classes)
    {
      CHBXClasses.Children.Add(new CheckBox()
      {
        Content = clazz,
        Margin = new Thickness(10, 0, 0, 0)
      }
      );
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
