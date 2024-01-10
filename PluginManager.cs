using System.Reflection;
using System.Text.Json;
using TTMC.Thunderstore;

namespace Lithium_Launcher
{
	public partial class PluginManager : Form
	{
		private PackageIndexEntry? selectedObject = null;
		private Form1 form;
		private Thunderstore thunderstore;
		private List<PackageIndexEntry> packageIndexEntries = new();
		private Task? task = null;
		public PluginManager(Form1 form, Thunderstore thunderstore)
		{
			InitializeComponent();
			this.thunderstore = thunderstore;
			this.form = form;
			task = new(() => LoadEntries());
			task.Start();
		}
		private void LoadEntries()
		{
			StreamReader reader = new(thunderstore.GetPackageIndexStream());
			while (true)
			{
				string? line = reader.ReadLine();
				if (string.IsNullOrEmpty(line))
				{
					break;
				}
				PackageIndexEntry entry = JsonSerializer.Deserialize<PackageIndexEntry>(line) ?? throw new("Invalid response");
				packageIndexEntries.Add(entry);
				if (!string.IsNullOrEmpty(entry.name) && !listBox1.Items.Contains(entry.name))
				{
					listBox1.Items.Add(entry.name);
				}
				Text = $"Plugin Manager ({packageIndexEntries.Count} plugins loaded)";
			}
			search.Enabled = true;
		}
		private void search_TextChanged(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			Search(textBox.Text);
		}
		private void Search(string? search = null)
		{
			listBox1.Items.Clear();
			foreach (PackageIndexEntry packageIndexEntry in packageIndexEntries)
			{
				if (!string.IsNullOrEmpty(packageIndexEntry.name) && (string.IsNullOrEmpty(search) || packageIndexEntry.name.Contains(search)) && !listBox1.Items.Contains(packageIndexEntry.name))
				{
					listBox1.Items.Add(packageIndexEntry.name);
				}
			}
		}
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			download.Enabled = false;
			listBox2.Items.Clear();
			if (listBox1.SelectedIndex >= 0 && listBox1.SelectedItem != null)
			{
				foreach (PackageIndexEntry packageIndexEntry in packageIndexEntries.Where(x => x.name == listBox1.SelectedItem.ToString()))
				{
					if (!string.IsNullOrEmpty(packageIndexEntry.version_number))
					{
						listBox2.Items.Add(packageIndexEntry.version_number);
					}
				}
			}
		}
		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			download.Enabled = false;
			if (listBox1.SelectedIndex >= 0 && listBox2.SelectedIndex >= 0 && listBox1.SelectedItem != null && listBox2.SelectedItem != null)
			{
				PackageIndexEntry? packageIndexEntry = packageIndexEntries.Where(x => x.name == listBox1.SelectedItem.ToString() && x.version_number == listBox2.SelectedItem.ToString()).FirstOrDefault();
				if (packageIndexEntry != default)
				{
					selectedObject = packageIndexEntry;
					download.Enabled = true;
				}
			}
		}
		private void download_Click(object sender, EventArgs e)
		{
			if (selectedObject != null && !string.IsNullOrEmpty(selectedObject.nspace) && !string.IsNullOrEmpty(selectedObject.name) && !string.IsNullOrEmpty(selectedObject.version_number))
			{
				PackageVersionExperimental packageVersion = thunderstore.GetPackageVersion(selectedObject.nspace, selectedObject.name, selectedObject.version_number);
				Stream stream = packageVersion.Download();
				form.DownloadPlugin(stream);
				Close();
			}
		}
	}
}