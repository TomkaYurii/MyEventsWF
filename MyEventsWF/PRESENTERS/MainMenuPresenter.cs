using Microsoft.Extensions.Logging;
using MVP.Views;
using MyEventsWF.Forms;

namespace MyEventsWF.PRESENTERS
{
    internal class MainMenuPresenter
    {
        //MVP MainMenuView
        private IMainMenuView mainMenuView;

        //GH Services Field
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger logger;

        public MainMenuPresenter(IMainMenuView mainMenuView,
            IServiceProvider serviceProvider,
            ILogger<MainMenuPresenter> logger)
        {
            this.mainMenuView = mainMenuView;
            this.serviceProvider = serviceProvider;
            this.logger = logger;

            this.mainMenuView.ShowGalleryView += ShowGalleryHandler;
        }


        private void ShowGalleryHandler(object sender, EventArgs e)
        {
            this.logger.LogInformation("MVP: Форма перегляду галерей завантажується " + DateTime.UtcNow);


            //IPetView view = PetView.GetInstace((MainView)mainView);
            //IPetRepository repository = new PetRepository(sqlConnectionString);
            //new PetPresenter(view, repository);
        }
    }
}


//    this.logger.LogInformation("Форма перегляду галерей завантажена " + DateTime.UtcNow);
//    var galleryForm = this.serviceProvider.GetRequiredService<GalleryForm>();
//    galleryForm.MdiParent = this;
//    OpenChildForm(galleryForm, sender);