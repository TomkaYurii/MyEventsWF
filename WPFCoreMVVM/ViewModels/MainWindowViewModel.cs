using WPFCoreMVVM.ViewModels;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using System.Windows.Input;
using WPFCoreMVVM.Infrastructure.Commands;
using WPFCoreMVVM.Services.Interfaces;
using WPFCoreMVVM.ViewModels.Base;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using MyEventsAdoNetDB.Repositories.Interfaces;

namespace WPFCoreMVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IDataService _DataService;
        private readonly ILogger<MainWindowViewModel> _logger;
        public MainWindowViewModel(IUserDialog UserDialog,
            IDataService DataService,
            ILogger<MainWindowViewModel> logger)
        {
            _UserDialog = UserDialog;
            _DataService = DataService;
            _logger = logger;
        }


        #region Title : string - Заголовок віна
        
        /// <summary>Заголовок вікна</summary>
        private string _Title = "Главное окно";

        /// <summary>Заголовок вікна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Status : string - Статус

        /// <summary>Статус</summary>
        private string _Status = "Готов!";

        /// <summary>Статус</summary>
        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion


        #region CurrentModel : ViewModel - Поточна дочірня модель представлення

        /// <summary>Поточна дочірня модель - представлення</summary>
        private ViewModel _CurrentModel;

        /// <summary>Поточна дочірня модель - представлення</summary>
        public ViewModel CurrentModel { get => _CurrentModel; private set => Set(ref _CurrentModel, value); }

        #endregion

        #region Command ShowEventsViewCommand - Відобразити представлення івентів

        /// <summary>Відобразити предсталвення івентів</summary>
        private ICommand _ShowEventsViewCommand;

        /// <summary>Відобразити предсталвення івентів</summary>
        public ICommand ShowEventsViewCommand => _ShowEventsViewCommand
            ??= new LambdaCommand(OnShowEventsViewCommandExecuted, CanShowEventsViewCommandExecute);

        /// <summary>Перевірка можливості виконання - Відобразити предсталвення івентів</summary>
        private bool CanShowEventsViewCommandExecute() => true;

        /// <summary>Логіка виконання - Відобразити предсталвення івентів</summary>
        private void OnShowEventsViewCommandExecuted()
        {
            _logger.LogInformation(DateTime.UtcNow + "=>" + "Отримуємо USER CONTROL OF EVENTS");
            this.CurrentModel = new EventsViewModel();
        }

        #endregion

        #region Command ShowProfileViewCommand - Відобразити представлення профайлу

        /// <summary>Відобразити представлення профайлу</summary>
        private ICommand _ShowProfileViewCommand;

        /// <summary>Відобразити представлення профайлу</summary>
        public ICommand ShowProfileViewCommand => _ShowProfileViewCommand
            ??= new LambdaCommand(OnShowProfileViewCommandExecuted, CanShowProfileViewCommandExecute);

        /// <summary>Перевірка можливості виконання - Відобразити представлення профайлу</summary>
        private bool CanShowProfileViewCommandExecute() => true;

        /// <summary>Логіка виконання - Відобразити представлення профайлу</summary>
        private void OnShowProfileViewCommandExecuted()
        {
            _logger.LogInformation(DateTime.UtcNow + "=>" + "Отримуємо USER CONTROL OF PROFILE");
            CurrentModel = new ProfileViewModel();
        }

        #endregion


    }
}
