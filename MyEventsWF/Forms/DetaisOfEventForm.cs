using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using MyEventsWF.Helpers;
using System.Data;

namespace MyEventsWF.Forms
{
    public partial class DetaisOfEventForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<DetaisOfEventForm> logger;
        private readonly ServiceArgs args;

        private Event my_event;

        public DetaisOfEventForm(IServiceProvider serviceProvider, 
            ILogger<DetaisOfEventForm> logger,
            ServiceArgs args)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            this.args = args;
        }

        #region "COLOR THEME"
        //Get all controls on a form
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        // Update Styles of Controls
        private void LoadTheme()
        {
            foreach (Button btn in GetAll(this, typeof(Button)))
            {
                btn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
            foreach (Label lbl in GetAll(this, typeof(Label)))
            {
                lbl.Font = new System.Drawing.Font("Verdana", 12.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.ForeColor = ThemeColor.PrimaryColor;
            }
            foreach (TextBox txtb in GetAll(this, typeof(TextBox)))
            {
                txtb.Font = new System.Drawing.Font("Verdana", 120.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtb.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        #endregion



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
                    this.logger.LogError(DateTime.UtcNow + "=>" + "Запит до БД... Щось пішло не так: " + ex.Message);
                    MessageBox.Show(ex.Message, "ПОМИЛКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async void DetaisOfEventForm_Load(object sender, EventArgs e)
        {
            await GetEventInformationAsync(args.Id);
            LoadTheme();

            this.label1.Text = my_event.Name;

            try
            {
                this.label10.Text = my_event.City.Name;
            }
            catch(Exception ex) { }

            try
            {
                this.label16.Text = my_event.Country.Name;
            }
            catch(Exception ex) { }

            this.label11.Text = my_event.Address;

            this.label12.Text = Convert.ToString(my_event.DateOfEvent);

            this.label13.Text = Convert.ToString(my_event.TimeOfEvent);

            this.label14.Text = Convert.ToString(my_event.AcceptableAge);

            this.label15.Text = Convert.ToString(my_event.CostOfVisit);
        }






        //конфігурування вікна при завантаженні
        private void DetaisOfEventForm_Configuring()
        {
            //textBox1.Text = this.args.Id.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DetaisOfEventForm_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}