using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hci2020_doctors_ui.ViewModel.Base
{
    public class UpdateViewCommand : ICommand
    {

        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel vm)
        {
            this.viewModel = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            else if (parameter.ToString() == "Calendar")
            {
                viewModel.SelectedViewModel = new CalendarViewModel();
            }
        }
    }
}
