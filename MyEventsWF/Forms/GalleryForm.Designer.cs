namespace MyEventsWF.Forms
{
    partial class GalleryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNameOfEvent = new System.Windows.Forms.Label();
            this.lblNameOfGallery = new System.Windows.Forms.Label();
            this.btnImageLoad = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNameOfEvent
            // 
            this.lblNameOfEvent.AutoSize = true;
            this.lblNameOfEvent.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNameOfEvent.Location = new System.Drawing.Point(200, 10);
            this.lblNameOfEvent.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.lblNameOfEvent.Name = "lblNameOfEvent";
            this.lblNameOfEvent.Size = new System.Drawing.Size(24, 31);
            this.lblNameOfEvent.TabIndex = 1;
            this.lblNameOfEvent.Text = "?";
            // 
            // lblNameOfGallery
            // 
            this.lblNameOfGallery.AutoSize = true;
            this.lblNameOfGallery.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNameOfGallery.Location = new System.Drawing.Point(499, 10);
            this.lblNameOfGallery.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.lblNameOfGallery.Name = "lblNameOfGallery";
            this.lblNameOfGallery.Size = new System.Drawing.Size(24, 31);
            this.lblNameOfGallery.TabIndex = 2;
            this.lblNameOfGallery.Text = "?";
            // 
            // btnImageLoad
            // 
            this.btnImageLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImageLoad.FlatAppearance.BorderSize = 0;
            this.btnImageLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImageLoad.Location = new System.Drawing.Point(826, 10);
            this.btnImageLoad.Margin = new System.Windows.Forms.Padding(300, 10, 3, 5);
            this.btnImageLoad.Name = "btnImageLoad";
            this.btnImageLoad.Size = new System.Drawing.Size(192, 29);
            this.btnImageLoad.TabIndex = 1;
            this.btnImageLoad.Text = "Add New Image";
            this.btnImageLoad.UseVisualStyleBackColor = true;
            this.btnImageLoad.Click += new System.EventHandler(this.btnImageLoad_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.lblNameOfEvent);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lblNameOfGallery);
            this.flowLayoutPanel1.Controls.Add(this.btnImageLoad);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1100, 50);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "NAME OF EVENT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(277, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(50, 10, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "NAME OF GALLERY:";
            // 
            // GalleryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "GalleryForm";
            this.Text = "Галерея івенту";
            this.Load += new System.EventHandler(this.GalleryForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnImageLoad;
        private Label lblNameOfEvent;
        private Label lblNameOfGallery;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label label2;
    }
}