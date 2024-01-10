using System.Diagnostics;
using System.IO.Compression;
using TTMC.Thunderstore;
using TTMC.GitHub;

namespace Lithium_Launcher
{
	public partial class Form1 : Form
	{
		private string path = "E:\\SteamLibrary\\steamapps\\common\\Lethal Company\\";
		private GitHub bepInEx = new GitHub("BepInEx", "BepInEx");
		private Release latestBepInEx;
		private Thunderstore thunderstore;
		private Task? task = null;
		private HttpClient client;
		private string[] plugins = [];
		public Form1()
		{
			client = new();
			thunderstore = new();
			InitializeComponent();
			if (File.Exists("path.txt"))
			{
				path = File.ReadAllText("path.txt");
			}
			else
			{
				MessageBox.Show("Please locate the root folder of Lethal Company");
				FolderBrowserDialog folderBrowserDialog = new();
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					path = folderBrowserDialog.SelectedPath;
					File.WriteAllText("path.txt", path);
				}
				else
				{
					Close();
				}
			}
			listBox1.Items.Add("Death Zone");
			latestBepInEx = bepInEx.LatestRelease();
			info.Text = latestBepInEx.body;
		}
		private void play_Click(object sender, EventArgs e)
		{
			if (play.Text == "Download")
			{
				task = new(() => DownloadPlugins(plugins));
				task.Start();
			}
			else if (play.Text == "Play")
			{
				string executable = path + "Lethal Company.exe";
				if (File.Exists(executable))
				{
					Process.Start(executable);
				}
			}
		}
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			bool check = listBox.SelectedIndex >= 0;
			if (check && listBox.SelectedIndex == 0)
			{
				plugins = client.GetStringAsync("https://cdn.discordapp.com/attachments/1186334563388100648/1194389922715537540/lethal.txt").Result.Split('\n');
				Enhance();
			}
			play.Enabled = check;
		}
		private void DownloadPlugin(string nspace, string name)
		{
			PackageExperimental package = thunderstore.GetPackage(nspace, name);
			PackageVersionExperimental? latest = package.latest;
			if (latest != null)
			{
				Stream stream = latest.Download();
				ZipArchive zipArchive = new(stream);
				if (zipArchive.Entries.Where(x => x.FullName.StartsWith("BepInEx")).Count() > 0)
				{
					zipArchive.ExtractToDirectory(path, true);
				}
				else if (zipArchive.Entries.Where(x => x.FullName.StartsWith("plugins")).Count() > 0)
				{
					zipArchive.ExtractToDirectory(path + "BepInEx", true);
				}
				else
				{
					zipArchive.ExtractToDirectory(path + "BepInEx\\plugins", true);
				}
				zipArchive.Dispose();
				stream.Close();
				stream.Dispose();
			}
		}
		private void DownloadPlugins(string[] plugins)
		{
			play.Enabled = false;
			play.Text = "Downloading";
			progress.Value = 0;
			Directory.Delete(path + "BepInEx", true);
			if (listBox1.SelectedIndex == 0)
			{
				Release release = bepInEx.LatestRelease();
				if (release.assets != null)
				{
					Asset asset = release.assets.Where(asset => !string.IsNullOrEmpty(asset.name) && asset.name.Contains(Environment.Is64BitProcess ? "x64" : "x86")).FirstOrDefault() ?? release.assets.First();
					Stream stream = asset.Download();
					ZipArchive zipArchive = new(stream);
					zipArchive.ExtractToDirectory(path, true);
				}
				for (int i = 0; i < plugins.Length; i++)
				{
					string plugin = plugins[i];
					string[] split = plugin.Split('/');
					DownloadPlugin(split[6], split[7]);
					progress.Value = (int)((i + 1) / (float)plugins.Length * 100);
					progress.Refresh();
				}
				DownloadPlugin("2018", "LC_API");
				File.Move(path + "BepInEx\\plugins\\LC_API.dll", path + "LC_API.dll", true);
			}
			play.Text = "Play";
			play.Enabled = true;
			File.WriteAllLines(path + "downloaded.txt", plugins);
		}
		private void Enhance()
		{
			string[] local = File.Exists(path + "downloaded.txt") ? File.ReadAllText(path + "downloaded.txt").Split("\r\n").Where(x => !string.IsNullOrEmpty(x)).ToArray() : [];
			if (local.Length == plugins.Length && plugins.Union(local).Count() == plugins.Length)
			{
				play.Text = "Play";

			}
			else
			{
				play.Text = "Download";
			}
		}
		private void modpackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				plugins = File.ReadAllLines(openFileDialog.FileName);
				Enhance();
				play.Enabled = true;
			}
		}
	}
}