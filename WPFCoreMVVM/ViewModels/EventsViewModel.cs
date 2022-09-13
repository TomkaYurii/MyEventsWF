using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPFCoreMVVM.Infrastructure.Commands;
using WPFCoreMVVM.Services;
using WPFCoreMVVM.Services.Interfaces;
using WPFCoreMVVM.ViewModels.Base;
using static System.Reflection.Metadata.BlobBuilder;

namespace WPFCoreMVVM.ViewModels
{
    class EventsViewModel : ViewModel
    {
        public EventsViewModel()
        {
            _ = OnLoadDataCommandExecuted();
        }

        #region Колекція івентів для виводу 
        /// <summary>Колекція івентів</summary>
        private ObservableCollection<Event> _events;

        /// <summary>Коллекция івентів</summary>
        public ObservableCollection<Event> Events
        {
            get => _events;
            set
            {
                if (Set(ref _events, value))
                {
                    _eventsViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(Event.Name), ListSortDirection.Ascending)
                        }
                    };

                    _eventsViewSource.Filter += OnEventsFilter;
                    _eventsViewSource.View.Refresh();

                    OnPropertyChanged(nameof(EventsView));
                }
            }
        }
        #endregion

        #region EventsFilter : string - Шукане слово
        /// <summary>Шукане слово</summary>
        private string _eventsFilter;

        /// <summary>Шукане слово</summary>
        public string EventsFilter
        {
            get => _eventsFilter;
            set
            {
                if (Set(ref _eventsFilter, value))
                    _eventsViewSource.View.Refresh();
            }
        }
        #endregion

        #region SelectedEvent : Event - Вибраний івент

        /// <summary>Выбранная книга</summary>
        private Event _SelectedEvent;

        /// <summary>Выбранная книга</summary>
        public Event SelectedEvent { get => _SelectedEvent; set => Set(ref _SelectedEvent, value); }

        #endregion

        private CollectionViewSource _eventsViewSource;

        public ICollectionView EventsView => _eventsViewSource?.View;

        private void OnEventsFilter(object Sender, FilterEventArgs E)
        {
            if (!(E.Item is Event ev) || string.IsNullOrEmpty(EventsFilter)) return;

            if (!ev.Name.Contains(EventsFilter))
                E.Accepted = false;
        }


        #region Command LoadDataCommand - Команда завантаження даних з БД

        /// <summary>Команда завантаження даних з репозиторію</summary>
        private ICommand _LoadDataCommand;

        /// <summary>Команда завантаження даних з репозиторію</summary>
        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        /// <summary>Перевірка можливості виконання - Команда завантаження даних з репозиторію</summary>
        private bool CanLoadDataCommandExecute() => true;

        /// <summary>Логіка виконання - Команда завантаження даних з репозиторію</summary>
        private async Task OnLoadDataCommandExecuted()
        {
            using (var scopeServices = App.Services.CreateScope())
            {
                var services = scopeServices.ServiceProvider;
                var _uow = services.GetService<IEFUnitOfWork>();
                var allevents = await _uow.EFEventRepository.GetAllAsync();
                this.Events = new ObservableCollection<Event>(allevents);
            }
        }
        #endregion

        #region Command AddNewEventCommand - Додавання нового івенту
        /// <summary>Додавання нового івенту</summary>
        private ICommand _AddNewEventCommand;

        /// <summary>Додавання ногового івенту</summary>
        public ICommand AddNewEventCommand => _AddNewEventCommand
            ??= new LambdaCommand(OnAddNewEventCommandExecuted, CanAddNewEventCommandExecute);

        /// <summary>Перевірка можливості виконання - Додавання нового івенту</summary>
        private bool CanAddNewEventCommandExecute() => true;

        /// <summary>Логіка виконання - Додавання нового івенту</summary>
        private void OnAddNewEventCommandExecuted()
        {
            /// код додавання нової книги
            using (var scopeServices = App.Services.CreateScope())
            {
                var services = scopeServices.ServiceProvider;
                var logger = services.GetService<ILogger<EventsViewModel>>();
                logger.LogInformation(DateTime.UtcNow + "=>" + "Здійснюємо додавання нового івенту з нової форми");
            }
        }
        #endregion

        #region Command RemoveEventCommand : Event - Видалення вказаного івенту

        /// <summary>Видалення вказаного івенту</summary>
        private ICommand _RemoveEventCommand;

        /// <summary>Видалення вказаного івенту</summary>
        public ICommand RemoveEventCommand => _RemoveEventCommand
            ??= new LambdaCommand(OnRemoveEventCommandExecuted, CanRemoveEventCommandExecute);

        /// <summary>Перевірка можливості виконання - видалення вказаного івенту</summary>
        private bool CanRemoveEventCommandExecute() => true;

        /// <summary>Перевірка можливості виконання - Видалення вказаного івенту</summary>
        private void OnRemoveEventCommandExecuted()
        {
            using (var scopeServices = App.Services.CreateScope())
            {
                var services = scopeServices.ServiceProvider;
                var logger = services.GetService<ILogger<EventsViewModel>>();
                logger.LogInformation(DateTime.UtcNow + "=>" + "Здійснюємо видалення вказаного івенту");
            }
        }

        #endregion
    }
}
