using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsAdoNetDB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEventsWF.Forms
{
    public partial class GalleryForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<GalleryForm> logger;

        public GalleryForm(IServiceProvider serviceProvider, ILogger<GalleryForm> logger)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        // ============================
        // Налаштування кольорової теми
        // ============================
        private void LoadTheme()
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.Font = new System.Drawing.Font("Verdana", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.Font = new System.Drawing.Font("Verdana", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.ForeColor = ThemeColor.PrimaryColor;
            }
            foreach (TextBox txtb in this.Controls.OfType<TextBox>())
            {
                txtb.Font = new System.Drawing.Font("Verdana", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtb.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        // EVENTS
        private async void GalleryForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: інформації про галерею із введеним Id");
            using (IServiceScope serviceScope = this.serviceProvider.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                var _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
                try
                {
                    this.logger.LogInformation(DateTime.UtcNow + "=>" + "1.1. Запит до БД: запит до таблиці Galeries");
                    var id_of_gallery = Convert.ToInt32(textBox3.Text);
                    var galleryinfo = await _unitOfWork._galleryRepository.GetAsync(id_of_gallery);
                    textBox4.Text = galleryinfo.Name;

                    // 1 Gallery - n Image
                    // SELECT * FROM IMAGE WHERE GALLERY_ID = 5
                    this.logger.LogInformation(DateTime.UtcNow + "=>" + "1.2. Запит до БД: запит до таблиці Images");
                    var images = await _unitOfWork._imageRepository.GetAllImagesByGalleryIdAsync(galleryinfo.Id);
                    var images_list = images.ToList();
                    textBox5.Text = images_list[0].Name;

                    _unitOfWork.Commit();  
                }
                catch (Exception ex)
                {
                    label3.Show();
                    label3.Text = ex.Message;
                }
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: отримання галереї по Id");
            using (IServiceScope serviceScope = this.serviceProvider.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                var _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
                try
                {
                    label3.BackColor = Color.Red;
                    label3.Hide();
                    label3.Text = "";
                    int id = Convert.ToInt32(textBox1.Text);
                    var mygallery = await _unitOfWork._galleryRepository.GetAsync(id);
                    textBox2.Text = mygallery.Name;
                    _unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    label3.Show();
                    label3.Text = ex.Message;
                }
            }
        }
    }
}
