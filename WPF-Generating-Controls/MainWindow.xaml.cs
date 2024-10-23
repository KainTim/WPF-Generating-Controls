using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Generating_Controls;
public partial class MainWindow : Window
{
  public MainWindow() => InitializeComponent();

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
    InitCBX();
    InitCHBX();
    InitRBSubjects();
    InitRBLevels();
  }

  private void InitRBLevels()
  {
    for (int i = 1; i <= 5; i++)
    {

      RadioButton rb = new RadioButton()
      {
        HorizontalAlignment = HorizontalAlignment.Center,
        Content = i,
        Background = new SolidColorBrush(Colors.SkyBlue),
        FontFamily = new FontFamily("Courier New"),
        FontSize = 16,
        Foreground = new SolidColorBrush(Colors.Red),
      };

      rb.Checked += RB_Levels_OnClick;
      RBLevels.Children.Add(rb);
    }
  }
  private void InitRBSubjects()
  {
    foreach (var subject in Configuration.Subjects)
    {
      RadioButton rb = new RadioButton()
      {
        Content = subject,
        Margin = new Thickness(0, 10, 0, 0)
      };

      rb.Checked += RB_Subject_OnClick;
      RBSubjects.Children.Add(rb);
    }
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
    classes.Sort();
    foreach (var clazz in classes)
    {
      var chbx = new CheckBox()
      {
        Content = clazz,
        Margin = new Thickness(5),
        IsChecked = true,
      };
      chbx.Checked += CHBXClazz_OnCheckChanged;
      chbx.Unchecked += CHBXClazz_OnCheckChanged;
      CHBXClasses.Children.Add(chbx);
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
  }


  private void CHBXClazz_OnCheckChanged(object sender, RoutedEventArgs routedEventArgs)
  {
    bool isChecked = ((CheckBox)sender).IsChecked ?? true;
    string classname = (string)((CheckBox)sender).Content;
    if (isChecked)
    {
      int prevCount= CBXNames.Items.Count;
      foreach (Student configStudent in Configuration.Students)
      {
        if (configStudent.Clazz == classname & !CBXNames.Items.Contains(configStudent))
        {
          CBXNames.Items.Add(configStudent);
        }
      }
      if(prevCount == 0) CBXNames.SelectedIndex = 0;
    }
    if (!isChecked)
    {
      foreach (Student student in Configuration.Students)
      {
        if (student.Clazz == classname)
        {
          CBXNames.Items.Remove(student);
        }
      }
    }
  }
  private void RB_Levels_OnClick(object sender, RoutedEventArgs e)
  {

  }
    private void RB_Subject_OnClick(object sender, RoutedEventArgs e)
  {

  }
  private void SaveItem_Click(object sender, RoutedEventArgs e)
  {

  }
  private void LoadItem_Click(object sender, RoutedEventArgs e)
  {

  }
  private void AddBtn_Click(object sender, RoutedEventArgs e)
  {

  }
}
