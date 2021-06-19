using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Task_Manager.Model;

namespace Task_Manager.ViewModel
{
    class Task_ViewModel : INotifyPropertyChanged
    {
        private Task_ViewModel()
        {
                
        }

        private static Task_ViewModel instance = null;

        public static Task_ViewModel GetInstance()
        {
            if (instance == null) { 
                instance = new Task_ViewModel(); 
            } 
            return instance; 
        }


        private ObservableCollection<_Task> tasks = new ObservableCollection<_Task>();

        public ObservableCollection<_Task> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

        private _Task selectedTask;

        public _Task SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
