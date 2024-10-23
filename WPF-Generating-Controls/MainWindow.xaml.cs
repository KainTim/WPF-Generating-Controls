using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
    var image = new BitmapImage();
    image.BeginInit();
    image.UriSource = new Uri(((Student)CBXNames.SelectedItem).ImagePath, UriKind.Relative);
    image.CacheOption = BitmapCacheOption.OnLoad;
    image.EndInit();
    ImgStudent.Source = image;
    LsBxServices.ItemsSource = ((Student)CBXNames.SelectedItem).Services;
    LsBxServices.Items.Refresh();
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
      RBLevels.Children.Add(rb);
    }
    ((RadioButton)RBLevels.Children[0]).IsChecked = true;
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
      RBSubjects.Children.Add(rb);
    }
    ((RadioButton)RBSubjects.Children[0]).IsChecked = true;
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
    CBXNames.SelectionChanged += CBXSelection_Changed;
    LsBxServices.ItemsSource = ((Student)CBXNames.SelectedItem).Services;
    LsBxServices.Items.Refresh();
  }


  private void CHBXClazz_OnCheckChanged(object sender, RoutedEventArgs routedEventArgs)
  {
    bool isChecked = ((CheckBox)sender).IsChecked ?? true;
    string classname = (string)((CheckBox)sender).Content;
    if (isChecked)
    {
      int prevCount = CBXNames.Items.Count;
      foreach (Student configStudent in Configuration.Students)
      {
        if (configStudent.Clazz == classname & !CBXNames.Items.Contains(configStudent))
        {
          CBXNames.Items.Add(configStudent);
        }
      }
      if (prevCount == 0) CBXNames.SelectedIndex = 0;
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
  private void SaveItem_Click(object sender, RoutedEventArgs e)
  {
    Configuration.SaveServices();
  }
  private void LoadItem_Click(object sender, RoutedEventArgs e)
  {
    Configuration.LoadServices();
    LsBxServices.Items.Refresh();
  }
  private void AddBtn_Click(object sender, RoutedEventArgs e)
  {
    Student student = (Student)CBXNames.SelectedItem;
    student.Services.Add(new Service()
    {
      Subject = getSelectedRBSubjectsItem(),
      Level = getSelectedRBLevelItem(),
    });
    LsBxServices.Items.Refresh();
  }
  private void CBXSelection_Changed(object sender, RoutedEventArgs e)
  {
    var comboBox = (ComboBox)sender;

    if (comboBox.SelectedItem == null)
    {
      ImgStudent.Source = null;
      LsBxServices.ItemsSource = null;
      return;
    }
    var image = new BitmapImage();
    image.BeginInit();
    image.UriSource = new Uri(((Student)comboBox.SelectedItem).ImagePath, UriKind.Relative);
    image.CacheOption = BitmapCacheOption.OnLoad;
    image.EndInit();
    ImgStudent.Source = image;
    LsBxServices.ItemsSource = ((Student)comboBox.SelectedItem).Services;
    LsBxServices.Items.Refresh();
  }
  private int getSelectedRBLevelItem()
  {
    int selectedLevel = -1;
    foreach (var level in RBLevels.Children)
    {
      if (level is RadioButton)
      {
        RadioButton radioButtonLevel = (RadioButton)level;
        selectedLevel = radioButtonLevel.IsChecked ?? false ? (int)radioButtonLevel.Content : selectedLevel;
      }
    }
    return selectedLevel;
  }
  private string getSelectedRBSubjectsItem()
  {
    string selectedSubject = "";
    foreach (var subject in RBSubjects.Children)
    {
      if (subject is RadioButton)
      {
        RadioButton radioButtonLevel = (RadioButton)subject;
        selectedSubject = radioButtonLevel.IsChecked ?? false ? (string)radioButtonLevel.Content : selectedSubject;
      }
    }
    return selectedSubject;
  }
}
