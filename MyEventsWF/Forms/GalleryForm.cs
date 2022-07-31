using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using MyEventsWF.Helpers;
using System.Drawing.Imaging;

namespace MyEventsWF.Forms
{
    public partial class GalleryForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<GalleryForm> logger;
        private readonly ServiceArgs args;

        private Event my_event;
        private string fileNameforUpload = "";

        public GalleryForm(IServiceProvider serviceProvider,
            ILogger<GalleryForm> logger,
            ServiceArgs serviceArgs)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            this.args = serviceArgs;
        }

        #region "COLOR THEME"
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
        #endregion

        #region "DYNAMICALLY CONTROLS CREATION"
        private TableLayoutPanel tableLayoutPanelBuild()
        {
            var tlp = new TableLayoutPanel();

            int columns = 5;
            int rows = this.my_event.Gallery.Images.Count / 5 + 1;
            for (int x = 0; x < rows; x++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 200));

                for (int y = 0; y < columns; y++)
                {
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                    //Create the controls
                    PictureBox img = new PictureBox();
                    img.Dock = DockStyle.Fill;
                    img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    var images = this.my_event.Gallery.Images.ToList();
                    if (x * columns + y < images.Count)
                    {
                        img.Name = images[x * columns + y].Id.ToString();
                        img.Image = ByteToImage(images[x * columns + y].ImageBytes);
                    }
                    img.MouseHover += new EventHandler(this.OnDeleteImg);
                    img.MouseLeave += new EventHandler(this.NotDeleteImg);
                    img.Click += new EventHandler(this.DeleteImageFromGallery);
                    tlp.Controls.Add(img, y, x);
                }
            }
            tlp.Dock = DockStyle.Fill;
            tlp.Name = "tlp_GalleryImages";
            tlp.AutoScroll = true;
            tlp.Margin = new System.Windows.Forms.Padding(1);
            return tlp;
        }
        private void OnDeleteImg(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            box.SizeMode = PictureBoxSizeMode.StretchImage;

            Button delButton = new Button();
            delButton.Text = "Click if you want to delete it";
            delButton.FlatStyle = FlatStyle.Flat;
            delButton.BackColor = Color.Red;
            delButton.ForeColor = Color.White;
            delButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            delButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            delButton.Dock = DockStyle.Bottom;
            box.Controls.Add(delButton);
        }
        private void NotDeleteImg(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;

            foreach (Control control in box.Controls)
            {
                if (control.GetType() == typeof(Button))
                    box.Controls.Remove(control);
            }
            box.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private async void DeleteImageFromGallery(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            this.logger.LogInformation(DateTime.UtcNow + "=>" + "Видалення із БД зображення");
            using (IServiceScope serviceScope = this.serviceProvider.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                var _unitOfWork = provider.GetRequiredService<IEFUnitOfWork>();
                try
                {
                    await _unitOfWork.EFImageRepository.DeleteAsync(Convert.ToInt32(box.Name));
                    await _unitOfWork.SaveChangesAsync();
                    MessageBox.Show("DELETED!", "DONE!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: шось пішло не так: " + ex.Message);
                    MessageBox.Show(ex.Message, "ПОМИЛКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TableLayoutPanel tblp =  (TableLayoutPanel)box.Parent;
            tblp.Controls.Remove((PictureBox)sender);

        }

        public Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        #endregion

        #region "WORK WITH DB"
        /// <summary>
        /// получение информации про ивент для которого мы просматриваем изображения с гелерии
        /// </summary>
        /// <param name="event_Id"></param>
        /// <returns></returns>
        private async Task GetEventInformationAsync(int event_Id)
        {
            this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит інформації про івент");
            using (IServiceScope serviceScope = this.serviceProvider.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                var _unitOfWork = provider.GetRequiredService<IEFUnitOfWork>();
                try
                {
                    this.my_event = await _unitOfWork.EFEventRepository.GetCompleteEntityAsync(event_Id);
                }
                catch (Exception ex)
                {
                    this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: шось пішло не так: " + ex.Message);
                    MessageBox.Show(ex.Message, "ПОМИЛКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// В этом методе создается и выполняется параметризированный запрос insert, который заносит уменьшенную копию 
        /// выбранной картинки в БД уменьшенная копия создается в методе CreateCopy()
        /// </summary>
        public async Task LoadPictureToDbAsync()
        {
            this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запис до БД зображення");
            using (IServiceScope serviceScope = this.serviceProvider.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                var _unitOfWork = provider.GetRequiredService<IEFUnitOfWork>();
                try
                {
                    MyEventsEntityFrameworkDb.Entities.Image _im = new MyEventsEntityFrameworkDb.Entities.Image();
                    _im.Name = fileNameforUpload + "_" + DateTime.Now;
                    _im.GalleryId = this.my_event.GalleryId;
                    _im.UserId = this.my_event.UserId;
                    _im.ImageBytes = CreateCopy();

                    await _unitOfWork.EFImageRepository.AddAsync(_im);
                    await _unitOfWork.SaveChangesAsync();
                    MessageBox.Show("Всьо файно!", "DONE!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: шось пішло не так: " + ex.Message);
                    MessageBox.Show(ex.Message, "ПОМИЛКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// В этом методе анализируется ориентация картинки и создается копия этой картинки таким образом, 
        /// чтобы максимальный размер картинки (высота или ширина) не превышал 220 пикселей
        /// Пропорции картинки при этом не искажаются
        /// </summary>
        /// <returns>байтовый массив, содержащий уменьшенную копию </returns>
        private byte[] CreateCopy()
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(fileNameforUpload);
            int maxWidth = 220, maxHeight = 220;
            double ratioX = (double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            System.Drawing.Image mi = new Bitmap(newWidth, newHeight); // image в памяти
            Graphics g = Graphics.FromImage(mi);
            g.DrawImage(img, 0, 0, newWidth, newHeight);
            MemoryStream ms = new MemoryStream();                      // поток для ввода|вывода байт из памяти
            mi.Save(ms, ImageFormat.Jpeg);
            ms.Flush();                                                // выносим в поток все данные из буфера
            ms.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(ms);
            byte[] buf = br.ReadBytes((int)ms.Length);
            return buf;
        }
        #endregion

        #region "EVENTS OF FORM"
        // EVENTS
        private async void GalleryForm_Load(object sender, EventArgs e)
        {

            await GetEventInformationAsync(args.Id);
            LoadTheme();
            this.Controls.Add(tableLayoutPanelBuild());
            this.lblNameOfEvent.Text = this.my_event.Name;
            this.lblNameOfGallery.Text = this.my_event.Gallery.Name;
        }
        private async void btnImageLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Graphics File|*.bmp;*.gif;*.jpg;*.png";
            ofd.FileName = "";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileNameforUpload = ofd.FileName;
                await LoadPictureToDbAsync();
            }
        }
        #endregion
    }
}
