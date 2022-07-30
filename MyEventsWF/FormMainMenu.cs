using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsWF.Forms;
using System.Runtime.InteropServices;

namespace MyEventsWF
{
    public partial class FormMainMenu : Form
    {
        #region "FIELDS"
        //GH Services Field
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger logger;

        //Fields
        private Button currentButton;
        private Random random;
        private Form activeForm;
        private int borderSize = 1;
        private int tempIndex;
        #endregion

        #region "CONSTRUCTOR"
        public FormMainMenu(IServiceProvider serviceProvider,
            ILogger<FormMainMenu> logger)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;

            // BORDERS
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(0, 0, 0);

            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        #endregion

        #region "BORDERLESS WINDOW MOVE/RESIZE"
        //This gives us the ability to drag the borderless form to a new location
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        //This gives us the drop shadow behind the borderless form
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }


        //This gives us the ability to resize the borderless from any borders instead of just the lower right corner
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htLeft = 10;
            const int htRight = 11;
            const int htTop = 12;
            const int htTopLeft = 13;
            const int htTopRight = 14;
            const int htBottom = 15;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;

            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
                ///allow resize on the lower right corner
                if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }
                ///allow resize on the lower left corner
                if (pt.X <= 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomRight : htBottomLeft);
                    return;
                }
                ///allow resize on the upper right corner
                if (pt.X <= 16 && pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htTopRight : htTopLeft);
                    return;
                }
                ///allow resize on the upper left corner
                if (pt.X >= clientSize.Width - 16 && pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htTopLeft : htTopRight);
                    return;
                }
                ///allow resize on the top border
                if (pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htTop);
                    return;
                }
                ///allow resize on the bottom border
                if (pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htBottom);
                    return;
                }
                ///allow resize on the left border
                if (pt.X <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htLeft);
                    return;
                }
                ///allow resize on the right border
                if (pt.X >= clientSize.Width - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htRight);
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        #region "METHODS"
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
            childForm.BringToFront();
            childForm.Show();
            lblTitleBar.Text = childForm.Text;
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
        #endregion

        #region "TITLE BAR BUTTONS EVENTS"
        // == Події кнопок на верхній панелі ==
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            //ctrl-leftclick anywhere on the control to drag the form to a new location 
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnTitleBarMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnTitleBarMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnTitleBarClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region "MENU EVENTS"
        // ==== ПОДІЇ МЕНЮ ====
        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("Завантаження форми перегляду профайлу користувача " + DateTime.UtcNow);
            var profileForm = this.serviceProvider.GetRequiredService<ProfileForm>();
            profileForm.MdiParent = this;
            OpenChildForm(profileForm, sender);
        }

        private void btnAllEvents_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("Форма перегляду всіх івентів завантажена " + DateTime.UtcNow);
            var allEventsForm = this.serviceProvider.GetRequiredService<AllEventsForm>();
            allEventsForm.MdiParent = this;
            OpenChildForm(allEventsForm, sender);
        }

        private void btnDetailsOfEvent_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("Форма перегляду деталей івенту завантажена " + DateTime.UtcNow);
            var detaisOfEventForm = this.serviceProvider.GetRequiredService<DetaisOfEventForm>();
            detaisOfEventForm.MdiParent = this;
            OpenChildForm(detaisOfEventForm, sender);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("Форма перегляду категорій завантажена " + DateTime.UtcNow);
            var categoryForm = this.serviceProvider.GetRequiredService<CategoryForm>();
            categoryForm.MdiParent = this;
            OpenChildForm(categoryForm, sender);
        }

        private void btnGallery_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("Форма перегляду галерей завантажена " + DateTime.UtcNow);
            var galleryForm = this.serviceProvider.GetRequiredService<GalleryForm>();
            galleryForm.MdiParent = this;
            OpenChildForm(galleryForm, sender);
        }

        private void btnForum_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("Форма перегляду форуму завантажена " + DateTime.UtcNow);
            var forumForm = this.serviceProvider.GetRequiredService<ForumForm>();
            forumForm.MdiParent = this;
            OpenChildForm(forumForm, sender);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.logger.LogInformation("Закриваю головне вікно");
            ActivateButton(sender);
            Application.Exit();
        }
        #endregion
    }
}