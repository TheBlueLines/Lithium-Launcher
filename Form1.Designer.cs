namespace Lithium_Launcher
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			play = new Button();
			listBox1 = new ListBox();
			info = new Label();
			progress = new ProgressBar();
			menuStrip1 = new MenuStrip();
			openToolStripMenuItem = new ToolStripMenuItem();
			modpackToolStripMenuItem = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// play
			// 
			play.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			play.Enabled = false;
			play.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
			play.Location = new Point(12, 367);
			play.Name = "play";
			play.Size = new Size(776, 42);
			play.TabIndex = 0;
			play.Text = "Welcome";
			play.UseVisualStyleBackColor = true;
			play.Click += play_Click;
			// 
			// listBox1
			// 
			listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			listBox1.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 33;
			listBox1.Location = new Point(12, 27);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(200, 334);
			listBox1.TabIndex = 1;
			listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
			// 
			// info
			// 
			info.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			info.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
			info.Location = new Point(218, 27);
			info.Name = "info";
			info.Size = new Size(570, 334);
			info.TabIndex = 2;
			info.Text = "TTMC Corporation";
			info.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// progress
			// 
			progress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			progress.Location = new Point(12, 415);
			progress.Name = "progress";
			progress.Size = new Size(776, 23);
			progress.TabIndex = 3;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(800, 24);
			menuStrip1.TabIndex = 4;
			menuStrip1.Text = "menuStrip1";
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { modpackToolStripMenuItem });
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.Size = new Size(48, 20);
			openToolStripMenuItem.Text = "Open";
			// 
			// modpackToolStripMenuItem
			// 
			modpackToolStripMenuItem.Name = "modpackToolStripMenuItem";
			modpackToolStripMenuItem.Size = new Size(124, 22);
			modpackToolStripMenuItem.Text = "Modpack";
			modpackToolStripMenuItem.Click += modpackToolStripMenuItem_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(progress);
			Controls.Add(info);
			Controls.Add(listBox1);
			Controls.Add(play);
			Controls.Add(menuStrip1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			Name = "Form1";
			Text = "Lithium Launcher";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button play;
		private ListBox listBox1;
		private Label info;
		private ProgressBar progress;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripMenuItem modpackToolStripMenuItem;
	}
}
