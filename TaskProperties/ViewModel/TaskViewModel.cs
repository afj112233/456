using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TaskProperties.Model;
using GalaSoft;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace TaskProperties.ViewModel
{
    class TaskViewModel : ViewModelBase
    {
        public List<string> GetScheduled => Model.Schedule.GetScheduled();

        public List<string> GetUnscheduled => Model.Schedule.GetUnscheduled();

        public List<string> GetTypeList => Model.Configuration.GetTypeList();

        public List<string> GetTriggerList => Model.Configuration.GetTriggerList();

        public TaskViewModel()
        {
            Yes = new RelayCommand(ExecuteYes);
            No = new RelayCommand(ExecuteNo);
            App = new RelayCommand(ExecuteApp);
            Help = new RelayCommand(ExecuteHelp);
            Left = new RelayCommand(ExecuteLeft);
            Right = new RelayCommand(ExecuteRight);
            Down = new RelayCommand(ExecuteDown);
            Up = new RelayCommand(ExecuteUp);
            TypeChoose = new RelayCommand(ExecuteType);
            TagChoose = new RelayCommand(ExecuteTag);
            CorrectInput = new RelayCommand(ExecuteCorrect);
            CorrectInput2 = new RelayCommand(ExecuteCorrect2);
            CorrectInput3 = new RelayCommand(ExecuteCorrect3);
            Check = new RelayCommand(ExecuteCheck);
        }

        public RelayCommand Yes { get; set; }
        public RelayCommand No { get; set; }
        public RelayCommand App { get; set; }
        public RelayCommand Help { get; set; }
        public RelayCommand Left { get; set; }
        public RelayCommand Right { get; set; }
        public RelayCommand Up { get; set; }
        public RelayCommand Down { get; set; }
        public RelayCommand TypeChoose { get; set; }
        public RelayCommand TagChoose { get; set; }
        public RelayCommand CorrectInput { get; set; }
        public RelayCommand CorrectInput2 { get; set; }

        public RelayCommand CorrectInput3 { get; set; }

        public RelayCommand Check { get; set; }
        public void ExecuteYes()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            string message = mainWindow.GeneralName.Text;
            if (message.Length == 0)
            {
                mainWindow.TabControl1.SelectedIndex = 0;
                string name = Model.Schedule.ScheduleList[0];
                MessageBox.Show($"Failed to modify properties for task \"{name}\".Invalid name.", "Logix Designer", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
            }
            else if (!(message[0] >= 'a' && message[0] <= 'z') && !(message[0] >= 'A' && message[0] <= 'Z'))
            {
                mainWindow.TabControl1.SelectedIndex = 0;
                string name = Model.Schedule.ScheduleList[0];
                MessageBox.Show($"Failed to modify properties for task \"{name}\".Invalid name.", "Logix Designer", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
            }
            else mainWindow.Close();
        }

        public void ExecuteNo()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            mainWindow.Close();
        }

        public void ExecuteApp()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            string message = mainWindow.GeneralName.Text;
            if (message.Length == 0)
            {
                mainWindow.TabControl1.SelectedIndex = 0;
                string name = Model.Schedule.ScheduleList[0];
                MessageBox.Show($"Failed to modify properties for task \"{name}\".Invalid name.", "Logix Designer", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
            }
            else if (!(message[0] >= 'a' && message[0] <= 'z') && !(message[0] >= 'A' && message[0] <= 'Z'))
            {
                mainWindow.TabControl1.SelectedIndex = 0;
                string name = Model.Schedule.ScheduleList[0];
                MessageBox.Show($"Failed to modify properties for task \"{name}\".Invalid name.", "Logix Designer", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
            }
            else
            {
                mainWindow.Title = "Task Properties - " + message;
            }
        }

        public void ExecuteHelp()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            int choose = mainWindow.TabControl1.SelectedIndex;
            switch (choose)
            {
                case 0:
                    MessageBox.Show($"这个页面输入Name，Name必须以英文字母开头\nName合法时点击应用替换标题，点击确定结束进程\n非法输入下点击确定和应用会切换回该界面", "Help", MessageBoxButton.OK, MessageBoxImage.Question);
                    break;
                case 1:
                    MessageBox.Show($"选择Type切换三个视图\n输入框不允许输入非数字和非小数点\nTrigger的第五种模式会禁用tag选项", "Help", MessageBoxButton.OK, MessageBoxImage.Question);
                    break;
                case 2:
                    MessageBox.Show($"使用4个按钮来调整两个listview的内容\nlistview内双击等于单击一次按钮", "Help", MessageBoxButton.OK, MessageBoxImage.Question);
                    break;
                case 3:
                    MessageBox.Show($"暂无功能", "Help", MessageBoxButton.OK, MessageBoxImage.Question);
                    break;
            }
        }
        public void ExecuteRight()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            if (Schedule.UnscheduleList.Count > 0)
            {
                string message = mainWindow.ListView1.SelectedItem.ToString();
                Schedule.UnscheduleList.Remove(message);
                Schedule.ScheduleList.Add(message);
                mainWindow.ListView1.ItemsSource = null;
                mainWindow.ListView1.ItemsSource = GetUnscheduled;
                mainWindow.ListView2.ItemsSource = null;
                mainWindow.ListView2.ItemsSource = GetScheduled;
                mainWindow.ListView1.SelectedIndex = 0;
                mainWindow.ListView2.SelectedIndex = 0;
            }
        }
        public void ExecuteLeft()
        {
            var mainWindow
                = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            if (Schedule.ScheduleList.Count > 0)
            {
                string message = mainWindow.ListView2.SelectedItem.ToString();
                Schedule.ScheduleList.Remove(message);
                Schedule.UnscheduleList.Add(message);
                mainWindow.ListView1.ItemsSource = null;
                mainWindow.ListView1.ItemsSource = GetUnscheduled;
                mainWindow.ListView2.ItemsSource = null;
                mainWindow.ListView2.ItemsSource = GetScheduled;
                mainWindow.ListView1.SelectedIndex = 0;
                mainWindow.ListView2.SelectedIndex = 0;
            }
        }
        public void ExecuteUp()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            if (mainWindow.ListView2.SelectedIndex > 0)
            {
                int pos = mainWindow.ListView2.SelectedIndex;
                string message = mainWindow.ListView2.SelectedItem.ToString();
                Schedule.ScheduleList[pos] = Schedule.ScheduleList[pos - 1];
                Schedule.ScheduleList[pos - 1] = message;
                mainWindow.ListView2.ItemsSource = null;
                mainWindow.ListView2.ItemsSource = GetScheduled;
                mainWindow.ListView2.SelectedIndex = pos - 1;
            }
        }
        public void ExecuteDown()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            if (mainWindow.ListView2.SelectedIndex < mainWindow.ListView2.Items.Count-1)
            {
                int pos = mainWindow.ListView2.SelectedIndex;
                string message = mainWindow.ListView2.SelectedItem.ToString();
                Schedule.ScheduleList[pos] = Schedule.ScheduleList[pos + 1];
                Schedule.ScheduleList[pos + 1] = message;
                mainWindow.ListView2.ItemsSource = null;
                mainWindow.ListView2.ItemsSource = GetScheduled;
                mainWindow.ListView2.SelectedIndex = pos + 1;
            }
        }

        public void ExecuteType()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            int chance = mainWindow.ComboBox1.SelectedIndex;
            switch (chance)
            {
                case 0:
                    Grid.SetRow(mainWindow.Block4,1);
                    Grid.SetRow(mainWindow.ConfigurationInput1, 1);
                    Grid.SetRow(mainWindow.ms, 1);
                    Grid.SetRow(mainWindow.CheckBox1, 2);
                    Grid.SetRow(mainWindow.CheckBox2, 3);
                    mainWindow.Block5.Visibility = Visibility.Hidden;
                    mainWindow.ConfigurationInput2.Visibility = Visibility.Hidden;
                    mainWindow.ms2.Visibility = Visibility.Hidden;
                    mainWindow.ms3.Visibility = Visibility.Hidden;
                    mainWindow.Block7.Visibility = Visibility.Hidden;
                    mainWindow.ConfigurationInput3.Visibility = Visibility.Hidden;
                    mainWindow.Block8.Visibility = Visibility.Hidden;
                    mainWindow.Block6.Visibility = Visibility.Hidden;
                    mainWindow.ComboBox2.Visibility = Visibility.Hidden;
                    mainWindow.Block9.Visibility = Visibility.Hidden;
                    mainWindow.ComboBox3.Visibility = Visibility.Hidden;
                    mainWindow.CheckBox4.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    Grid.SetRow(mainWindow.Block4, 3);
                    Grid.SetRow(mainWindow.ConfigurationInput1, 3);
                    Grid.SetRow(mainWindow.ms, 3);
                    Grid.SetRow(mainWindow.CheckBox1, 4);
                    Grid.SetRow(mainWindow.CheckBox2, 5);
                    mainWindow.Block5.Visibility = Visibility.Visible;
                    mainWindow.ConfigurationInput2.Visibility = Visibility.Visible;
                    mainWindow.ConfigurationInput2.IsEnabled = true;
                    Grid.SetRow(mainWindow.ConfigurationInput2, 1);
                    Grid.SetColumn(mainWindow.ConfigurationInput2, 2);
                    mainWindow.ConfigurationInput2.HorizontalAlignment = HorizontalAlignment.Left;
                    mainWindow.ms2.Visibility = Visibility.Visible;
                    mainWindow.Block7.Visibility = Visibility.Visible;
                    mainWindow.ConfigurationInput3.Visibility = Visibility.Visible;
                    mainWindow.Block8.Visibility = Visibility.Visible;
                    mainWindow.Block6.Visibility = Visibility.Hidden;
                    mainWindow.ComboBox2.Visibility = Visibility.Hidden;
                    Grid.SetRow(mainWindow.Block7, 2);
                    Grid.SetRow(mainWindow.ConfigurationInput3, 2);
                    Grid.SetRow(mainWindow.Block8, 2);
                    mainWindow.Block9.Visibility = Visibility.Hidden;
                    mainWindow.ComboBox3.Visibility = Visibility.Hidden;
                    mainWindow.CheckBox4.Visibility = Visibility.Hidden;
                    mainWindow.ms3.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Grid.SetRow(mainWindow.Block4, 5);
                    Grid.SetRow(mainWindow.ConfigurationInput1, 5);
                    Grid.SetRow(mainWindow.ms, 5);
                    Grid.SetRow(mainWindow.CheckBox1, 6);
                    Grid.SetRow(mainWindow.CheckBox2, 7);
                    mainWindow.Block5.Visibility = Visibility.Hidden;
                    mainWindow.ms2.Visibility = Visibility.Hidden;
                    mainWindow.Block7.Visibility = Visibility.Visible;
                    mainWindow.ConfigurationInput3.Visibility = Visibility.Visible;
                    mainWindow.Block8.Visibility = Visibility.Visible;
                    Grid.SetRow(mainWindow.Block7, 4);
                    Grid.SetRow(mainWindow.ConfigurationInput3, 4);
                    Grid.SetRow(mainWindow.Block8, 4);
                    mainWindow.Block6.Visibility = Visibility.Visible;
                    mainWindow.ComboBox2.Visibility = Visibility.Visible;
                    mainWindow.Block9.Visibility = Visibility.Visible;
                    mainWindow.ComboBox3.Visibility = Visibility.Visible;
                    mainWindow.CheckBox4.Visibility = Visibility.Visible;
                    mainWindow.ms3.Visibility = Visibility.Visible;
                    mainWindow.ConfigurationInput2.Visibility = Visibility.Visible;
                    Grid.SetRow(mainWindow.ConfigurationInput2, 3);
                    Grid.SetColumn(mainWindow.ConfigurationInput2, 2);
                    mainWindow.ConfigurationInput2.HorizontalAlignment = HorizontalAlignment.Right;
                    if (mainWindow.CheckBox4.IsChecked != null)
                        mainWindow.ConfigurationInput2.IsEnabled = (bool)mainWindow.CheckBox4.IsChecked;
                    break;
            }
        }

        public void ExecuteTag()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            int chance = mainWindow.ComboBox2.SelectedIndex;
            if (chance == 4)
            {
                mainWindow.ComboBox3.IsEnabled = false;
            }
            else mainWindow.ComboBox3.IsEnabled = true;
        }

        public void ExecuteCorrect()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            string message = mainWindow.ConfigurationInput1.Text;
            int index = mainWindow.ConfigurationInput1.SelectionStart;
            for (var i = 0; i < message.Length; i++)
            {
                if (!(message[i] >= '0' && message[i] <= '9')&&message[i] != '.')
                {
                    mainWindow.ConfigurationInput1.Text=message.Remove(i, 1);
                    index--;
                }
            }

            mainWindow.ConfigurationInput1.SelectionStart = index;
        }

        public void ExecuteCorrect2()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            string message = mainWindow.ConfigurationInput2.Text;
            int index = mainWindow.ConfigurationInput2.SelectionStart;
            for (var i = 0; i < message.Length; i++)
            {
                if (!(message[i] >= '0' && message[i] <= '9') && message[i] != '.')
                {
                    mainWindow.ConfigurationInput2.Text = message.Remove(i, 1);
                    index--;
                }
            }

            mainWindow.ConfigurationInput2.SelectionStart = index;
        }

        public void ExecuteCorrect3()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            string message = mainWindow.ConfigurationInput3.Text;
            int index = mainWindow.ConfigurationInput3.SelectionStart;
            bool exist = false;
            for (var i = 0; i < message.Length; i++)
            {
                if (!(message[i] >= '0' && message[i] <= '9') && message[i] != '.')
                {
                    mainWindow.ConfigurationInput3.Text = message.Remove(i, 1);
                    mainWindow.Warnning.Visibility = Visibility.Visible;
                    exist = true;
                    index--;
                }
            }
            mainWindow.ConfigurationInput3.SelectionStart = index;
            if (exist == false)
            {
                mainWindow.Warnning.Visibility = Visibility.Hidden;
            }
        }

        public void ExecuteCheck()
        {
            var mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            if (mainWindow.CheckBox4.IsChecked == true)
            {
                mainWindow.ConfigurationInput2.IsEnabled = true;
            }
            else mainWindow.ConfigurationInput2.IsEnabled = false;
        }
    }
}
