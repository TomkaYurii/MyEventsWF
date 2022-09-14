using MyEventsEntityFrameworkDb.Entities;
using System;
using WPFCoreMVVM;

namespace MyEventsWpfMVVM.ViewModels
{ 
    internal class EventEditorViewModel : WPFCoreMVVM.ViewModels.Base.ViewModel
    {
        #region EventId : int - Ідентифікатор івенту

        public int EventId { get; }

        #endregion

        #region Name : string - Назва івенту

        /// <summary>Назва івенту</summary>
        private string _Name;

        /// <summary>Назва івенту</summary>
        public string Name { get => _Name; set => Set(ref _Name, value); }

        #endregion

        public EventEditorViewModel(Event ev)
        {
            EventId = ev.Id;
            Name = ev.Name;
        }

        public EventEditorViewModel() : this(new Event { Id = 1, Name = "Букварь!" })
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Не для рантайма");
        }
    }
}
