using WPFCoreMVVM.ViewModels;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using System.Windows.Input;
using WPFCoreMVVM.Infrastructure.Commands;
using WPFCoreMVVM.Services.Interfaces;
using WPFCoreMVVM.ViewModels.Base;

namespace WPFCoreMVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IDataService _DataService;
        private readonly IEFUnitOfWork _UOW;

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Главное окно";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Status : string - Статус

        /// <summary>Статус</summary>
        private string _Status = "Готов!";

        /// <summary>Статус</summary>
        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion


        #region CurrentModel : ViewModel - Текущая дочерняя модель-представления

        /// <summary>Текущая дочерняя модель-представления</summary>
        private ViewModel _CurrentModel;

        /// <summary>Текущая дочерняя модель-представления</summary>
        public ViewModel CurrentModel { get => _CurrentModel; private set => Set(ref _CurrentModel, value); }

        #endregion

        #region Command ShowBuyersViewCommand - Отобразить представление покупателей

        /// <summary>Отобразить представление покупателей</summary>
        private ICommand _ShowEventsViewCommand;

        /// <summary>Отобразить представление покупателей</summary>
        public ICommand ShowEventsViewCommand => _ShowEventsViewCommand
            ??= new LambdaCommand(OnShowEventsViewCommandExecuted, CanShowEventsViewCommandExecute);

        /// <summary>Проверка возможности выполнения - Отобразить представление покупателей</summary>
        private bool CanShowEventsViewCommandExecute() => true;

        /// <summary>Логика выполнения - Отобразить представление покупателей</summary>
        private void OnShowEventsViewCommandExecuted()
        {
            CurrentModel = new EventsViewModel(/*_UOW*/);
        }

        #endregion

        public MainWindowViewModel(IUserDialog UserDialog, IDataService DataService/*, IEFUnitOfWork uow*/)
        {
            _UserDialog = UserDialog;
            _DataService = DataService;
            //_UOW = uow;
        }
    }
}
