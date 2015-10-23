using DevExpress.XtraPrinting.Export.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DevExpressControls.Helpers
{
    public static class DirectoryManagmentUtils
    {
        public const int DisposeTimeout = 5;
        const string FolderKey = "WorkSessionDirectory";
        static readonly object modifyUserDirectoriesLocker = new object();

        public class DemoDirectoryInfo
        {
            public string Name { get; set; }
            public DateTime LastUsageTime { get; set; }
        }

        public static string DocumentBrowsingFolderPath { get { return Path.Combine(DirectoryManagmentUtils.CurrentDataDirectory, "DocumentBrowsing"); } }
        public static string CurrentDataDirectory
        {
            get
            {
                if (!Utils.IsSiteMode)
                    return InitialDemoFilesPath;
                lock (modifyUserDirectoriesLocker)
                {
                    var currentDataDirectory = (string)Context.Items[FolderKey];
                    if (currentDataDirectory == null)
                    {
                        Context.Items[FolderKey] = currentDataDirectory = CreateNewDemoFolder();
                        var directoryInfo = new DemoDirectoryInfo { Name = currentDataDirectory, LastUsageTime = DateTime.Now };
                        ActualDemoDirectories.Add(directoryInfo);
                    }
                    else
                    {
                        DemoDirectoryInfo directoryInfo = ActualDemoDirectories.Where(i => i.Name == currentDataDirectory).SingleOrDefault();
                        directoryInfo.LastUsageTime = DateTime.Now;
                    }
                    return currentDataDirectory;
                }
            }
        }

        static IList<DemoDirectoryInfo> actualDemoDirectories;
        static IList<DemoDirectoryInfo> ActualDemoDirectories
        {
            get
            {
                if (actualDemoDirectories == null)
                    actualDemoDirectories = new List<DemoDirectoryInfo>();
                return actualDemoDirectories;
            }
        }
        static HttpContext Context { get { return HttpContext.Current; } }
        static string RootDemoFilesPath { get { return Context.Request.MapPath("~/App_Data/"); } }
        static string InitialDemoFilesPath { get { return Path.Combine(RootDemoFilesPath, "Documents"); } }

        static string CreateNewDemoFolder()
        {
            string demoFilesDirectoty = GenerateDemoFilesFolderName();
            CopyDemoFiles(InitialDemoFilesPath, demoFilesDirectoty);
            return demoFilesDirectoty;
        }
        static void CopyDemoFiles(string sourceFilePath, string destinationPath)
        {
            IEnumerable<string> documentFileCollection = GetFilesInDirectory(sourceFilePath, "*.xlsx", "*.xls", "*.csv", "*.docx", "*.doc", "*.rtf", "*.txt");
            if (!Directory.Exists(destinationPath))
                Directory.CreateDirectory(destinationPath);
            foreach (var filePath in documentFileCollection)
            {
                string destinationFile = Path.Combine(destinationPath, Path.GetFileName(filePath));
                File.Copy(filePath, destinationFile, true);
                File.SetAttributes(destinationFile, FileAttributes.Normal);
            }

            foreach (string directoryPath in Directory.GetDirectories(sourceFilePath))
            {
                string directoryName = Path.GetFileName(directoryPath);
                CopyDemoFiles(directoryPath, Path.Combine(destinationPath, directoryName));
            }
        }
        static IEnumerable<string> GetFilesInDirectory(string path, params string[] allowedExtensions)
        {
            IEnumerable<string> documentFileCollection = new string[0];
            foreach (string extension in allowedExtensions)
            {
                documentFileCollection = documentFileCollection.Concat(Directory.GetFiles(path, extension));
            }
            return documentFileCollection;
        }
        static string GenerateDemoFilesFolderName()
        {
            string currentFolder = null;
            while (string.IsNullOrEmpty(currentFolder) || Directory.Exists(Path.Combine(RootDemoFilesPath, currentFolder)))
            {
                currentFolder = Guid.NewGuid().ToString();
            }
            return Path.Combine(RootDemoFilesPath, currentFolder);
        }
        public static void PurgeOldUserDirectories()
        {
            if (!Utils.IsSiteMode)
                return;

            lock (modifyUserDirectoriesLocker)
            {
                string[] existingDirectories = Directory.GetDirectories(RootDemoFilesPath);
                foreach (string directoryPath in existingDirectories)
                {
                    Guid guid = Guid.Empty;
                    if (!Guid.TryParse(Path.GetFileName(directoryPath), out guid)) continue;

                    DemoDirectoryInfo directoryInfo = ActualDemoDirectories.Where(i => i.Name == directoryPath).SingleOrDefault();
                    if (directoryInfo == null || (DateTime.Now - directoryInfo.LastUsageTime).TotalMinutes > DisposeTimeout)
                    {
                        Directory.Delete(directoryPath, true);
                        if (directoryInfo != null)
                            ActualDemoDirectories.Remove(directoryInfo);
                    }
                }
            }
        }
    }

    public class OfficeDemoPage : System.Web.UI.Page
    {
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            DirectoryManagmentUtils.PurgeOldUserDirectories();
        }
    }
}