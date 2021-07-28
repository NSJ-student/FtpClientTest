using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SFtpWPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            loadLocalDirList();
        }

        public void loadLocalDirList()
        {
//            listLocalFile.Items.Clear();
            List<UserFileInfo> fileItems = new List<UserFileInfo>();
            fileItems.Add(new UserFileInfo(".."));

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(LocalDirPath.Text);
            foreach (System.IO.DirectoryInfo Dir in di.GetDirectories())
            {
                String FileNameOnly = Dir.Name;
                fileItems.Add(new UserFileInfo(FileNameOnly));
            }
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                String FileNameOnly = File.Name;
                String FullFileName = File.FullName;
                String FileSize = File.Length.ToString("#,##0") + "B";

                fileItems.Add(new UserFileInfo(FileNameOnly, FileSize));
            }

            listLocalFile.ItemsSource = fileItems;
        }

        private void listLocalFileContextMenu_OnDoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            if (item == null || !item.IsSelected)
            {
                return;
            }

            UserFileInfo file_item = item.Content as UserFileInfo;
            if(!file_item.is_directory)
            {
                return;
            }

            if (file_item.Name == "..")
            {
                LocalDirPath.Text = get_parent_dir_path(LocalDirPath.Text);
                loadLocalDirList();
            }
            else
            {
                LocalDirPath.Text += "/" + file_item.Name;
                loadLocalDirList();
            }
        }
        private void listLocalFileContextMenu_OnUpload(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Local File Upload");
        }
        private void listLocalFileContextMenu_OnDownload(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Local File Download");
        }
        private void listLocalFileContextMenu_OnDelete(object sender, RoutedEventArgs e)
        {
            if(listLocalFile.SelectedItems.Count == 0)
            {
                return;
            }

            foreach(var selected_item in listLocalFile.SelectedItems)
            {
                UserFileInfo file_item = selected_item as UserFileInfo;
                if (file_item.is_directory)
                {
                    continue;
                }

                System.IO.File.Delete(LocalDirPath.Text + "/" + file_item.Name);
            }
            
            loadLocalDirList();
        }

        private void listRemoteFileContextMenu_OnDoubleClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Remote File DoubleClick");
        }
        private void listRemoteFileContextMenu_OnUpload(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Remote File Upload");
        }
        private void listRemoteFileContextMenu_OnDownload(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Remote File Download");
        }
        private void listRemoteFileContextMenu_OnDelete(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Remote File Delete");
        }

        private string get_parent_dir_path(string path)
        {
            // notice that i used two separators windows style "\\" and linux "/" (for bad formed paths)
            // We make sure to remove extra unneeded characters.
            string trim = path.TrimEnd('/', '\\');
            int index = trim.LastIndexOfAny(new char[] { '\\', '/' });

            // now if index is >= 0 that means we have at least one parent directory, otherwise the given path is the root most.
            if (index >= 0)
            {
                if (path.Remove(index).Last() == ':')
                {
                    return path.Remove(index) + "/";
                }
                else
                {
                    return path.Remove(index);
                }
            }
            else
            {
                return path;
            }
        }

    }

    public class UserFileInfo
    {
        public UserFileInfo(string name)
        {
            Image = new BitmapImage(new Uri("pack://application:,,,/Resources/folder.png"));
            Name = name;
            Size = "";
            is_directory = true;
        }
        public UserFileInfo(string name, string size)
        {
            Image = new BitmapImage(new Uri("pack://application:,,,/Resources/file.png"));
            Name = name;
            Size = size;
            is_directory = false;
        }
        public string Name { get; set; }
        public string Size { get; set; }
        public BitmapImage Image { get; }
        public bool is_directory { get; }
    }

    public class UserTxRxInfo
    {
        public UserTxRxInfo(string local, string remote, bool local_to_remote)
        {
            LocalPath = local;
            RemotePath = remote;
            if(local_to_remote)
            {
                Dir = "->";
            }
            else
            {
                Dir = "<-";
            }
            Progress = 0;
            Time = DateTime.Now.ToString("yyyy.MM.dd ") + DateTime.Now.ToString("HH:mm:ss");
        }
        public string LocalPath { get; set; }
        public string Dir { get; set; }
        public string RemotePath { get; set; }
        public int Progress { get; set; }
        public string Time { get; set; }
    }
}
