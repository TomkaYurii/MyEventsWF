using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsWF.Forms
{
    public partial class AllEventsForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<AllEventsForm> logger;
        private List<Event> top10events;

        public AllEventsForm(IServiceProvider serviceProvider, ILogger<AllEventsForm> logger)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        #region "COLOR THEME FOR WINDOW"
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

        #region "CARD CREATION"
        private Panel CardCreator(List<Event> list, int index)
        {
            // lblNAME
            var lblName = new Label();
            lblName.Dock = System.Windows.Forms.DockStyle.Top;
            lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblName.Location = new System.Drawing.Point(0, 0);
            lblName.Name = "lblNAME";
            lblName.Size = new System.Drawing.Size(210, 25);
            lblName.TabIndex = 0;
            lblName.Text = list[index].Name;
            lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // pctBImage
            var pctBImage = new PictureBox();
            pctBImage.Location = new System.Drawing.Point(0, 30);
            pctBImage.Size = new System.Drawing.Size(210, 105);
            pctBImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pctBImage.TabIndex = 1;
            pctBImage.TabStop = false;
            // lblDate
            var lblDate = new Label();
            lblDate.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            lblDate.AutoSize = true;
            lblDate.Location = new System.Drawing.Point(78, 138);
            lblDate.Size = new System.Drawing.Size(45, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = list[index].DateOfEvent.ToString();
            // panel
            var panel = new Panel();
            panel.BackColor = System.Drawing.Color.White;
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Location = new System.Drawing.Point(0, 0);
            panel.Margin = new System.Windows.Forms.Padding(1);
            panel.Size = new System.Drawing.Size(210, 320);
            panel.TabIndex = 0;
            // lblDiscription
            var lblDiscription = new Label();
            lblDiscription.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            lblDiscription.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDiscription.Location = new System.Drawing.Point(0, 168);
            lblDiscription.Size = new System.Drawing.Size(210, 108);
            lblDiscription.TabIndex = 3;
            lblDiscription.Text = list[index].Address;
            // btnDetails
            var btnDetails = new Button();
            btnDetails.BackColor = System.Drawing.Color.LightGray;
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDetails.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnDetails.Location = new System.Drawing.Point(113, 279);
            btnDetails.Size = new System.Drawing.Size(94, 29);
            btnDetails.TabIndex = 5;
            btnDetails.Text = "Details";
            btnDetails.UseVisualStyleBackColor = false;
            // btnDiscuss
            var btnDiscuss = new Button();
            btnDiscuss.BackColor = System.Drawing.Color.LightGray;
            btnDiscuss.FlatAppearance.BorderSize = 0;
            btnDiscuss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDiscuss.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnDiscuss.Location = new System.Drawing.Point(3, 279);
            btnDiscuss.Name = "btnDiscuss";
            btnDiscuss.Size = new System.Drawing.Size(94, 29);
            btnDiscuss.TabIndex = 4;
            btnDiscuss.Text = "Discuss";
            btnDiscuss.UseVisualStyleBackColor = false;
            btnDiscuss.Click += new System.EventHandler(OpenDetailsAboutEvent);

            panel.Controls.Add(lblName);
            panel.Controls.Add(pctBImage);
            panel.Controls.Add(lblDiscription);
            panel.Controls.Add(lblDate);
            panel.Controls.Add(btnDetails);
            panel.Controls.Add(btnDiscuss);
            return panel;
        }

        //public event EventHandler ButtonDiscussClicked;
        private void OpenDetailsAboutEvent(object sender, EventArgs e)
        {
            var forumForm = this.serviceProvider.GetRequiredService<ForumForm>();
            //forumForm.EventId = 10;
            forumForm.ShowDialog();
        }
        #endregion


        #region "EF to Database"
        public async Task GetEventsForStartScreenAsync()
        {
            this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: отримання найближчих 10 подій");
            using (IServiceScope serviceScope = this.serviceProvider.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                var _unitOfWork = provider.GetRequiredService<IEFUnitOfWork>();
                try
                {
                    var temp = await _unitOfWork.EFEventRepository.GetTop10EventsAsync();
                    this.top10events = temp.ToList();
                }
                catch
                {
                    this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: шось пішло не так");
                }
            }
        }
        #endregion

        #region "Events of Form"
        // EVENTS
        private async void AllEventsForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            await GetEventsForStartScreenAsync();
            int k = 0;
            for (int i = 0; i < tlpEvents.ColumnCount; i++)
            {
                k = 0;
                k = k + i;
                for (int j = 0; j < tlpEvents.RowCount; j++)
                {
                    tlpEvents.Controls.Add(CardCreator(this.top10events, k), i, j);
                    k = k + tlpEvents.ColumnCount;
                }
            }
        }
        #endregion
    }
}
