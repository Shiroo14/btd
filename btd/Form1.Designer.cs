namespace btd
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maxCPUOnBatteryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem100 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem75 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem50 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.inputValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxCPUOnBatteryToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 48);
            // 
            // maxCPUOnBatteryToolStripMenuItem
            // 
            this.maxCPUOnBatteryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputValueToolStripMenuItem,
            this.MenuItem100,
            this.MenuItem75,
            this.MenuItem50,
            this.MenuItem25});
            this.maxCPUOnBatteryToolStripMenuItem.Name = "maxCPUOnBatteryToolStripMenuItem";
            this.maxCPUOnBatteryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.maxCPUOnBatteryToolStripMenuItem.Text = "Max CPU on battery";
            // 
            // MenuItem100
            // 
            this.MenuItem100.Name = "MenuItem100";
            this.MenuItem100.Size = new System.Drawing.Size(180, 22);
            this.MenuItem100.Text = "100%";
            this.MenuItem100.Click += new System.EventHandler(this.MenuItem100_Click);
            // 
            // MenuItem75
            // 
            this.MenuItem75.Name = "MenuItem75";
            this.MenuItem75.Size = new System.Drawing.Size(180, 22);
            this.MenuItem75.Text = "75%";
            this.MenuItem75.Click += new System.EventHandler(this.MenuItem75_Click);
            // 
            // MenuItem50
            // 
            this.MenuItem50.Name = "MenuItem50";
            this.MenuItem50.Size = new System.Drawing.Size(180, 22);
            this.MenuItem50.Text = "50%";
            this.MenuItem50.Click += new System.EventHandler(this.MenuItem50_Click);
            // 
            // MenuItem25
            // 
            this.MenuItem25.Name = "MenuItem25";
            this.MenuItem25.Size = new System.Drawing.Size(180, 22);
            this.MenuItem25.Text = "25%";
            this.MenuItem25.Click += new System.EventHandler(this.MenuItem25_Click);
            // 
            // inputValueToolStripMenuItem
            // 
            this.inputValueToolStripMenuItem.Name = "inputValueToolStripMenuItem";
            this.inputValueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inputValueToolStripMenuItem.Text = "Input value";
            this.inputValueToolStripMenuItem.Click += new System.EventHandler(this.inputValueToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 10);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(10, 10);
            this.Name = "Form1";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem maxCPUOnBatteryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem100;
        private System.Windows.Forms.ToolStripMenuItem MenuItem75;
        private System.Windows.Forms.ToolStripMenuItem MenuItem50;
        private System.Windows.Forms.ToolStripMenuItem MenuItem25;
        private System.Windows.Forms.ToolStripMenuItem inputValueToolStripMenuItem;
    }
}

