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
    InitBTN();
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

      rb.Checked += RBClazz_OnClick;
      RBSubjects.Children.Add(rb);
    }
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
    classes.Sort();
    foreach (var clazz in classes)
    {
      Button btn = new Button()
      {
        Content = clazz,
        Margin = new Thickness(5, 5, 5, 0),
        Padding = new Thickness(2),
        Background = new LinearGradientBrush(Colors.Yellow, Colors.Green, 0)
      };
      btn.Click += BTN_OnClick;
      BtnClasses.Children.Add(btn);
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
    classes.Sort();
    foreach (var clazz in classes)
    {
      var chbx = new CheckBox()
      {
        Content = clazz,
        Margin = new Thickness(5, 0, 5, 0),
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
    LBLSelected.Content = $"{CBXNames.SelectedItem} selected";
    CBXNames.SelectionChanged += (s, e) => LBLSelected.Content = $"{CBXNames.SelectedItem} selected";
  }
  private void RBClazz_OnClick(object sender, RoutedEventArgs e)
  {
    LBLSelected.Content = $"{((RadioButton)sender).Content} selected";
  }
  private void CHBXClazz_OnCheckChanged(object sender, RoutedEventArgs routedEventArgs)
  {
    LBLSelected.Content = $"{((CheckBox)sender).Content} {(((CheckBox)sender).IsChecked ?? false ? "Checked" : "Unchecked")}";
  }
  private void RB_Levels_OnClick(object sender, RoutedEventArgs e)
  {
    LBLSelected.Content = $"Level {((RadioButton)sender).Content} selected";
  }

  private void BTN_OnClick(object sender, RoutedEventArgs routedEventArgs)
  {
    LBLSelected.Content = $"{((Button)sender).Content} clicked";
  }
}
