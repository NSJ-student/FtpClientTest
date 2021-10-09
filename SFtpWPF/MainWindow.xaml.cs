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
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace SFtpWPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        SftpClient m_sftpClient;
        List<UserTxRxInfo> listTxRxFile;
        UserTxRxInfo currentUploadItem;
        UserTxRxInfo currentDownloadtem;
        Thread uploadThread;
        Thread downloadThread;
        Thread connectThread;
        ulong uploadFileLength;
        ulong downloadFileLength;
        bool uploadActive;
        bool downloadActive;
        bool connected;

        public MainWindow()
        {
            InitializeComponent();

            uploadActive = false;
            downloadActive = false;
            listTxRxFile = new List<UserTxRxInfo>();
            loadLocalDirList();
        }

        public void loadLocalDirList()
        {
//            listLocalFile.Items.Clear();

            List<UserFileInfo> user_Items = new List<UserFileInfo>();
            user_Items.Add(new UserFileInfo(".."));

            List<UserFileInfo> dir_Items = new List<UserFileInfo>();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(LocalDirPath.Text);
            foreach (System.IO.DirectoryInfo Dir in di.GetDirectories())
            {
                String FileNameOnly = Dir.Name;
                dir_Items.Add(new UserFileInfo(FileNameOnly));
            }
            dir_Items = dir_Items.OrderBy(a => a.Name).ToList();

            List<UserFileInfo> file_Items = new List<UserFileInfo>();
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                String FileNameOnly = File.Name;
                String FullFileName = File.FullName;
                String FileSize = File.Length.ToString("#,##0") + "B";

                file_Items.Add(new UserFileInfo(FileNameOnly, FileSize));
            }
            file_Items = file_Items.OrderBy(a => a.Name).ToList();

            user_Items.AddRange(dir_Items);
            user_Items.AddRange(file_Items);
            listLocalFile.ItemsSource = user_Items;
        }

        public void loadRemoteDirList()
        {
            if (!connected)
            {
                return;
            }

//           listRemoteFile.Items.Clear();

            try
            {
                List<UserFileInfo> user_Items = new List<UserFileInfo>();
                user_Items.Add(new UserFileInfo(".."));

                List<UserFileInfo> dir_Items = new List<UserFileInfo>();
                foreach (var entry in m_sftpClient.ListDirectory(RemoteDirPath.Text))
                {
                    if (entry.IsDirectory)
                    {
                        String FileNameOnly = entry.Name;

                        if (FileNameOnly.Equals("."))
                        {
                            continue;
                        }
                        if (FileNameOnly.Equals(".."))
                        {
                            continue;
                        }
                        dir_Items.Add(new UserFileInfo(FileNameOnly));
                    }
                }
                dir_Items = dir_Items.OrderBy(a => a.Name).ToList();

                List<UserFileInfo> file_Items = new List<UserFileInfo>();
                foreach (var entry in m_sftpClient.ListDirectory(RemoteDirPath.Text))
                {
                    if (entry.IsRegularFile)
                    {
                        String FileNameOnly = entry.Name;
                        String FileSize = entry.Length.ToString("#,##0") + "B";

                        file_Items.Add(new UserFileInfo(FileNameOnly, FileSize));
                    }
                }
                file_Items = file_Items.OrderBy(a => a.Name).ToList();

                user_Items.AddRange(dir_Items);
                user_Items.AddRange(file_Items);
                listRemoteFile.ItemsSource = user_Items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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
            if (!connected)
            {
                return;
            }
            if (listLocalFile.SelectedItems.Count == 0)
            {
                return;
            }
            
            foreach (var selected_item in listLocalFile.SelectedItems)
            {
                UserFileInfo file_item = selected_item as UserFileInfo;
                if(file_item.Name.Equals(".."))
                {
                    continue;
                }
                listTxRxFile.Add(new UserTxRxInfo(
                    LocalDirPath.Text+"/"+file_item.Name, 
                    RemoteDirPath.Text + "/" + file_item.Name, 
                    true));
            }

            listProgressStatus.ItemsSource = listTxRxFile;
            ICollectionView view = CollectionViewSource.GetDefaultView(listProgressStatus.ItemsSource);
            view.Refresh();
            if(uploadActive)
            {
                return;
            }

            try
            {
                uploadThread = new Thread(() => uploadThreadFunc());

                uploadThread.IsBackground = true;
                uploadThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            loadRemoteDirList();
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
            ListViewItem item = sender as ListViewItem;
            if (item == null || !item.IsSelected)
            {
                return;
            }

            UserFileInfo file_item = item.Content as UserFileInfo;
            if (!file_item.is_directory)
            {
                return;
            }

            if (file_item.Name == "..")
            {
                RemoteDirPath.Text = get_parent_dir_path(RemoteDirPath.Text);
                loadRemoteDirList();
            }
            else
            {
                RemoteDirPath.Text += "/" + file_item.Name;
                loadRemoteDirList();
            }
        }
        private void listRemoteFileContextMenu_OnDownload(object sender, RoutedEventArgs e)
        {
            if (!connected)
            {
                return;
            }
            if (listRemoteFile.SelectedItems.Count == 0)
            {
                return;
            }

            foreach (var selected_item in listRemoteFile.SelectedItems)
            {
                UserFileInfo file_item = selected_item as UserFileInfo;
                if (file_item.Name.Equals(".."))
                {
                    continue;
                }
                listTxRxFile.Add(new UserTxRxInfo(
                    LocalDirPath.Text + "/" + file_item.Name,
                    RemoteDirPath.Text + "/" + file_item.Name,
                    false));
            }

            listProgressStatus.ItemsSource = listTxRxFile;
            ICollectionView view = CollectionViewSource.GetDefaultView(listProgressStatus.ItemsSource);
            view.Refresh();
            if(downloadActive)
            {
                return;
            }

            try
            {
                downloadThread = new Thread(() => downloadThreadFunc());

                downloadThread.IsBackground = true;
                downloadThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            loadLocalDirList();
        }
        private void listRemoteFileContextMenu_OnDelete(object sender, RoutedEventArgs e)
        {
            if (listRemoteFile.SelectedItems.Count == 0)
            {
                return;
            }

            foreach (var selected_item in listRemoteFile.SelectedItems)
            {
                UserFileInfo file_item = selected_item as UserFileInfo;
                if (file_item.is_directory)
                {
                    continue;
                }

                m_sftpClient.DeleteFile(RemoteDirPath.Text + "/" + file_item.Name);
            }

            loadRemoteDirList();
        }

        private void listProgressStatusContextMenu_OnClear(object sender, RoutedEventArgs e)
        {
            if(downloadActive)
            {
                return;
            }
            if(uploadActive)
            {
                return;
            }
            listTxRxFile.Clear();
            ICollectionView view = CollectionViewSource.GetDefaultView(listProgressStatus.ItemsSource);
            view.Refresh();
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

        private void uploadThreadFunc()
        {
            uploadActive = true;
            try
            {
                int loop_count = listTxRxFile.Count;
                bool retry = false;
                do
                {
                    loop_count = listTxRxFile.Count;
                    retry = false;
                    foreach (UserTxRxInfo item in listTxRxFile)
                    {
                        currentUploadItem = null;
                        if (item.Progress == 0 && item.Dir.Equals("->"))
                        {
                            currentUploadItem = item;
                            string localPath = item.LocalPath;
                            string remotePath = item.RemotePath;
                            Stream fileStream = new FileStream(localPath, FileMode.Open);

                            uploadFileLength = (ulong)fileStream.Length;
                            m_sftpClient.UploadFile(fileStream, remotePath, UpdateUploadProgresBar);
                            fileStream.Close();
                        }
                        if(loop_count != listTxRxFile.Count)
                        {
                            retry = true;
                            break;
                        }
                    }
                } while (retry);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Dispatcher.Invoke(new Action(loadRemoteDirList));
            uploadActive = false;
        }

        private void downloadThreadFunc()
        {
            downloadActive = true;
            try
            {
                int loop_count = listTxRxFile.Count;
                bool retry = false;
                do
                {
                    loop_count = listTxRxFile.Count;
                    retry = false;
                    foreach (UserTxRxInfo item in listTxRxFile)
                    {
                        currentDownloadtem = null;
                        if (item.Progress == 0 && item.Dir.Equals("<-"))
                        {
                            currentDownloadtem = item;
                            string localPath = item.LocalPath;
                            string remotePath = item.RemotePath;
                            Stream fileStream = File.Create(localPath);

                            SftpFile file = m_sftpClient.Get(remotePath);
                            long file_size = file.Attributes.Size;
                            downloadFileLength = (ulong)file_size;
                            m_sftpClient.DownloadFile(remotePath, fileStream, UpdateDownloadProgresBar);
                            fileStream.Close();
                        }
                        if (loop_count != listTxRxFile.Count)
                        {
                            retry = true;
                            break;
                        }
                    }
                } while (retry);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Dispatcher.Invoke(new Action(loadLocalDirList));
            downloadActive = false;
        }

        private void UpdateUploadProgresBar(ulong uploaded)
        {
            int percent = (int)((uploaded * 100) / uploadFileLength);
            // Update progress bar on foreground thread
            if(currentUploadItem != null)
            {
                currentUploadItem.Progress = percent;
            }
        }

        private void UpdateDownloadProgresBar(ulong uploaded)
        {
            int percent = (int)((uploaded * 100) / downloadFileLength);
            // Update progress bar on foreground thread
            if (currentDownloadtem != null)
            {
                currentDownloadtem.Progress = percent;
            }
        }

        private void btnSftpConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_sftpClient = new SftpClient(txtHost.Text, 22, txtUserName.Text, txtPassword.Password);
                m_sftpClient.KeepAliveInterval = TimeSpan.FromSeconds(60);
                m_sftpClient.ConnectionInfo.Timeout = TimeSpan.FromMinutes(180);
                m_sftpClient.OperationTimeout = TimeSpan.FromMinutes(180);

                connectThread = new Thread(() => connectThreadFunc());

                connectThread.IsBackground = true;
                connectThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void connectThreadFunc()
        {
            Dispatcher.Invoke(new Action(StartStopWait));
            try
            {
                m_sftpClient.Connect();
                connected = m_sftpClient.IsConnected;
                if (connected)
                {
                    Dispatcher.Invoke(delegate() { RemoteDirPath.Text = m_sftpClient.WorkingDirectory;  });
                    Dispatcher.Invoke(new Action(loadRemoteDirList));
                }
                else
                {
                    Console.WriteLine("connect failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Dispatcher.Invoke(new Action(StartStopWait));
        }

        private void StartStopWait()
        {
            LoadingAdorner.IsAdornerVisible = !LoadingAdorner.IsAdornerVisible;
            listRemoteFile.IsEnabled = !listRemoteFile.IsEnabled;
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
    
    public class UserTxRxInfo : INotifyPropertyChanged
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
            _progress = 0;
            Time = DateTime.Now.ToString("yyyy.MM.dd ") + DateTime.Now.ToString("HH:mm:ss");
        }
        public string LocalPath { get; set; }
        public string Dir { get; set; }
        public string RemotePath { get; set; }
        public string Time { get; set; }
        private int _progress;
        public int Progress
        {
            get
            {
                return _progress;
            }

            set
            {
                if (value != _progress)
                {
                    _progress = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
