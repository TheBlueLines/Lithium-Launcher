namespace Lithium_Launcher
{
	partial class PluginManager
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginManager));
			listBox1 = new ListBox();
			search = new TextBox();
			listBox2 = new ListBox();
			download = new Button();
			SuspendLayout();
			// 
			// listBox1
			// 
			listBox1.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 33;
			listBox1.Location = new Point(12, 58);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(300, 367);
			listBox1.TabIndex = 0;
			listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
			// 
			// search
			// 
			search.Enabled = false;
			search.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
			search.Location = new Point(12, 12);
			search.Name = "search";
			search.Size = new Size(606, 40);
			search.TabIndex = 1;
			search.TextChanged += search_TextChanged;
			// 
			// listBox2
			// 
			listBox2.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
			listBox2.FormattingEnabled = true;
			listBox2.ItemHeight = 33;
			listBox2.Location = new Point(318, 58);
			listBox2.Name = "listBox2";
			listBox2.Size = new Size(300, 367);
			listBox2.TabIndex = 2;
			listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
			// 
			// download
			// 
			download.Enabled = false;
			download.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
			download.Location = new Point(12, 431);
			download.Name = "download";
			download.Size = new Size(606, 50);
			download.TabIndex = 3;
			download.Text = "Download";
			download.UseVisualStyleBackColor = true;
			download.Click += download_Click;
			// 
			// PluginManager
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(630, 493);
			Controls.Add(download);
			Controls.Add(listBox2);
			Controls.Add(search);
			Controls.Add(listBox1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "PluginManager";
			Text = "Plugin Manager";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox listBox1;
		private TextBox search;
		private ListBox listBox2;
		private Button download;
	}
}