using Microsoft.Extensions.DependencyInjection;
using MyEventsWF.Forms;
using System.Runtime.InteropServices;

namespace MyEventsWF
{
    public partial class FormMainMenu : Form
    {
        //GH Services
        private readonly IServiceProvider serviceProvider;

        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public FormMainMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        // œ≤ƒ Àﬁ◊≈ÕÕﬂ ÃŒ∆À»¬Œ—“≤ –”’¿“» ¬≤ ÕŒ
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        // ==== Ã≈“Œƒ» ====
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);

        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Verdana", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 99);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Vardana", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleBar.Text = childForm.Text;
        }

        //Ã¿Õ≤œ”Àﬂ÷≤Ø ≤« ¬≤ ÕŒÃ
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitleBar.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnTitleBarClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTitleBarMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnTitleBarMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // ==== œŒƒ≤Ø ====
        private void btnProfile_Click(object sender, EventArgs e)
        {
            var profileForm = this.serviceProvider.GetRequiredService<ProfileForm>();
            OpenChildForm(profileForm, sender);
        }

        private void btnAllEvents_Click(object sender, EventArgs e)
        {
            var allEventsForm = this.serviceProvider.GetRequiredService<AllEventsForm>();
            OpenChildForm(allEventsForm, sender);
        }

        private void btnDetailsOfEvent_Click(object sender, EventArgs e)
        {
            var detaisOfEventForm = this.serviceProvider.GetRequiredService<DetaisOfEventForm>();
            OpenChildForm(detaisOfEventForm, sender);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            var categoryForm = this.serviceProvider.GetRequiredService<CategoryForm>();
            OpenChildForm(categoryForm, sender);
        }

        private void btnGallery_Click(object sender, EventArgs e)
        {
            var galleryForm = this.serviceProvider.GetRequiredService<GalleryForm>();
            OpenChildForm(galleryForm, sender);
        }

        private void btnForum_Click(object sender, EventArgs e)
        {
            var forumForm = this.serviceProvider.GetRequiredService<ForumForm>();
            OpenChildForm(forumForm, sender);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            Application.Exit();
        }
    }
}