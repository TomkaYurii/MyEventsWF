using MyEventsWpfMVVM.ViewModels;
using MyEventsWpfMVVM.Views.Windows;
using MyEventsEntityFrameworkDb.Entities;
using System.Windows;
using WPFCoreMVVM.Services.Interfaces;

namespace WPFCoreMVVM.Services
{
    internal class UserDialog : IUserDialog
    {
          public bool Edit(Event Event)
        {
            var Event_editor_model = new EventEditorViewModel(Event);

            var Event_editor_window = new EventEditorWindow
            {
                DataContext = Event_editor_model
            };

            if (Event_editor_window.ShowDialog() != true) return false;

            Event.Name = Event_editor_model.Name;

            return true;
        }

        public bool ConfirmInformation(string Information, string Caption) => MessageBox
           .Show(
                Information, Caption, 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Information)
                == MessageBoxResult.Yes;

        public bool ConfirmWarning(string Warning, string Caption) => MessageBox
           .Show(
                Warning, Caption, 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning)
                == MessageBoxResult.Yes;

        public bool ConfirmError(string Error, string Caption) => MessageBox
           .Show(
                Error, Caption, 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Error)
                == MessageBoxResult.Yes;
    }
}
