using Android.App;
using MyTriviaApp.Models;
using MyTriviaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTriviaApp.ViewModels
{
    internal class UserAdminPageViewModel
    {
        

        public ICommand RefreshStudentsCommand { get; private set; }
        public ICommand AddStudentCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; } 
        public ICommand ResetPointsCommand { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }


    }
}
