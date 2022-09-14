using MyEventsEntityFrameworkDb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCoreMVVM.Services.Interfaces
{
    internal interface IUserDialog
    {
        bool Edit(Event ev);

        bool ConfirmInformation(string Information, string Caption);
        bool ConfirmWarning(string Warning, string Caption);
        bool ConfirmError(string Error, string Caption);
    }
}
