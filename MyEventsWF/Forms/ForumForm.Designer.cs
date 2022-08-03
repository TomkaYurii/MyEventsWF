namespace MyEventsWF.Forms
{
    partial class ForumForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SearchMessages = new System.Windows.Forms.Button();
            this.SendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 10;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Знайти івент за назвою";
            this.textBox1.Size = new System.Drawing.Size(520, 23);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(563, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Знайти івент за ID";
            this.textBox2.Size = new System.Drawing.Size(147, 23);
            this.textBox2.TabIndex = 12;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(29, 73);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(793, 334);
            this.listBox1.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(29, 445);
            this.textBox3.Name = "textBox3";
            this.textBox3.PlaceholderText = "Написати коментар";
            this.textBox3.Size = new System.Drawing.Size(681, 23);
            this.textBox3.TabIndex = 14;
            // 
            // SearchMessages
            // 
            this.SearchMessages.Location = new System.Drawing.Point(723, 11);
            this.SearchMessages.Name = "SearchMessages";
            this.SearchMessages.Size = new System.Drawing.Size(99, 23);
            this.SearchMessages.TabIndex = 15;
            this.SearchMessages.Text = "Знайти";
            this.SearchMessages.UseVisualStyleBackColor = true;
            this.SearchMessages.Click += new System.EventHandler(this.SearchMessages_Click);
            // 
            // SendMessage
            // 
            this.SendMessage.Location = new System.Drawing.Point(723, 444);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(99, 23);
            this.SendMessage.TabIndex = 16;
            this.SendMessage.Text = "Відправити";
            this.SendMessage.UseVisualStyleBackColor = true;
            this.SendMessage.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // ForumForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.ControlBox = false;
            this.Controls.Add(this.SendMessage);
            this.Controls.Add(this.SearchMessages);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "ForumForm";
            this.Text = "Форум";
            this.Load += new System.EventHandler(this.ForumForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private ListBox listBox1;
        private TextBox textBox3;
        private Button SearchMessages;
        private Button SendMessage;
    }
}