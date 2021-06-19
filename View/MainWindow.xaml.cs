using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task_Manager.ViewModel;
using Task_Manager.Model;
using Microsoft.Win32;

namespace Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Process.GetProcesses().ToList().ForEach(i => Task_ViewModel.GetInstance().Tasks.Add(new _Task(i)));
            this.DataContext = Task_ViewModel.GetInstance();
        }

        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            if(this.tasks_ListView.SelectedItem != null)
            {
                try
                {
                    (this.tasks_ListView.SelectedItem as _Task).Process.Kill();
                    Task_ViewModel.GetInstance().Tasks.Remove(this.tasks_ListView.SelectedItem as _Task);
                }
                catch
                {
                    MessageBox.Show("Operation failed!");
                }
            }
            
        }

        private void Autorun_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            try
            {
                key.SetValue((this.tasks_ListView.SelectedItem as _Task).Name, (this.tasks_ListView.SelectedItem as _Task).Process);
                MessageBox.Show("Successfully added!");
            }
            catch
            {
                MessageBox.Show("Operation failed!");
            }
        }
    }
}
