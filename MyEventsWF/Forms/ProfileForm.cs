using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsAdoNetDB.Repositories.Interfaces;

namespace MyEventsWF.Forms
{
    public partial class ProfileForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<ProfileForm> logger;

        public ProfileForm(IServiceProvider serviceProvider, ILogger<ProfileForm> logger)
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
        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: отримання профайлу користувача по Id");
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
                    var userprofile = await _unitOfWork._userProfileRepository.GetAsync(id);
                    textBox2.Text = userprofile.First_Name;
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
