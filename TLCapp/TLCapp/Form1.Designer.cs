namespace TLCapp
{
    partial class TLC_form
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
            this.text_id = new System.Windows.Forms.TextBox();
            this.text_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.webbMain = new System.Windows.Forms.WebBrowser();
            this.Load_button = new System.Windows.Forms.Button();
            this.Enter_button = new System.Windows.Forms.Button();
            this.shifts_button = new System.Windows.Forms.Button();
            this.X_button = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.TextBox();
            this.debug_text = new System.Windows.Forms.TextBox();
            this.scrapeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_id
            // 
            this.text_id.Location = new System.Drawing.Point(46, 35);
            this.text_id.Name = "text_id";
            this.text_id.Size = new System.Drawing.Size(376, 22);
            this.text_id.TabIndex = 1;
            // 
            // text_password
            // 
            this.text_password.Location = new System.Drawing.Point(46, 86);
            this.text_password.Name = "text_password";
            this.text_password.Size = new System.Drawing.Size(376, 22);
            this.text_password.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employee ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // webbMain
            // 
            this.webbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webbMain.Location = new System.Drawing.Point(0, 393);
            this.webbMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.webbMain.Name = "webbMain";
            this.webbMain.Size = new System.Drawing.Size(897, 360);
            this.webbMain.TabIndex = 5;
            this.webbMain.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // Load_button
            // 
            this.Load_button.Location = new System.Drawing.Point(46, 138);
            this.Load_button.Name = "Load_button";
            this.Load_button.Size = new System.Drawing.Size(84, 57);
            this.Load_button.TabIndex = 7;
            this.Load_button.Text = "Load";
            this.Load_button.UseVisualStyleBackColor = true;
            this.Load_button.Click += new System.EventHandler(this.Load_button_Click);
            // 
            // Enter_button
            // 
            this.Enter_button.Location = new System.Drawing.Point(136, 138);
            this.Enter_button.Name = "Enter_button";
            this.Enter_button.Size = new System.Drawing.Size(90, 57);
            this.Enter_button.TabIndex = 8;
            this.Enter_button.Text = "Enter";
            this.Enter_button.UseVisualStyleBackColor = true;
            this.Enter_button.Click += new System.EventHandler(this.Enter_button_Click);
            // 
            // shifts_button
            // 
            this.shifts_button.Location = new System.Drawing.Point(232, 138);
            this.shifts_button.Name = "shifts_button";
            this.shifts_button.Size = new System.Drawing.Size(90, 57);
            this.shifts_button.TabIndex = 9;
            this.shifts_button.Text = "Get Shifts";
            this.shifts_button.UseVisualStyleBackColor = true;
            this.shifts_button.Click += new System.EventHandler(this.shifts_button_Click);
            // 
            // X_button
            // 
            this.X_button.BackColor = System.Drawing.Color.Red;
            this.X_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X_button.Location = new System.Drawing.Point(428, 33);
            this.X_button.Name = "X_button";
            this.X_button.Size = new System.Drawing.Size(116, 162);
            this.X_button.TabIndex = 10;
            this.X_button.Text = "X";
            this.X_button.UseVisualStyleBackColor = false;
            this.X_button.Click += new System.EventHandler(this.X_button_Click);
            // 
            // Output
            // 
            this.Output.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Output.Location = new System.Drawing.Point(0, 201);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(897, 192);
            this.Output.TabIndex = 11;
            // 
            // debug_text
            // 
            this.debug_text.Dock = System.Windows.Forms.DockStyle.Right;
            this.debug_text.Location = new System.Drawing.Point(550, 0);
            this.debug_text.Multiline = true;
            this.debug_text.Name = "debug_text";
            this.debug_text.ReadOnly = true;
            this.debug_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debug_text.Size = new System.Drawing.Size(347, 201);
            this.debug_text.TabIndex = 12;
            // 
            // scrapeButton
            // 
            this.scrapeButton.BackColor = System.Drawing.Color.Lime;
            this.scrapeButton.Location = new System.Drawing.Point(329, 138);
            this.scrapeButton.Name = "scrapeButton";
            this.scrapeButton.Size = new System.Drawing.Size(93, 57);
            this.scrapeButton.TabIndex = 13;
            this.scrapeButton.Text = "Scrape";
            this.scrapeButton.UseVisualStyleBackColor = false;
            this.scrapeButton.Click += new System.EventHandler(this.scrapeButton_Click);
            // 
            // TLC_form
            // 
            this.AcceptButton = this.X_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 753);
            this.Controls.Add(this.scrapeButton);
            this.Controls.Add(this.debug_text);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.X_button);
            this.Controls.Add(this.shifts_button);
            this.Controls.Add(this.Enter_button);
            this.Controls.Add(this.Load_button);
            this.Controls.Add(this.webbMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_password);
            this.Controls.Add(this.text_id);
            this.Location = new System.Drawing.Point(10, 20);
            this.Name = "TLC_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TLC App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox text_id;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser webbMain;
        private System.Windows.Forms.Button Load_button;
        private System.Windows.Forms.Button Enter_button;
        private System.Windows.Forms.Button shifts_button;
        private System.Windows.Forms.Button X_button;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.TextBox debug_text;
        private System.Windows.Forms.Button scrapeButton;
    }
}

