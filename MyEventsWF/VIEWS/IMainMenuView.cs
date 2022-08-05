using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Views
{
    public interface IMainMenuView
    {
        event EventHandler ShowProfileView;
        event EventHandler ShowAllEventsView;
        event EventHandler ShowDetailsOfEventView;
        event EventHandler ShowCategoryView;
        event EventHandler ShowGalleryView;
        event EventHandler ShowForumView;
    }
}
