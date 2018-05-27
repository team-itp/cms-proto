using CmsClient.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CmsClient.ViewModels
{
    public class MediaFileListViewModel : ViewModelBase
    {
        public class FileList : ObservableCollection<MediaFileViewModel> { }

        public FileList Files { get; }

        public bool IsWatching { get; private set; }
        public Task WatchTask { get; private set; }

        private SynchronizationContext _context;
        private string _pathToWatch;
        private FileSystemWatcher _watcher;
        private TaskCompletionSource<object> _tcs;

        public MediaFileListViewModel(string pathToWatch)
        {
            _context = SynchronizationContext.Current;
            _pathToWatch = pathToWatch;
            _watcher = new FileSystemWatcher(_pathToWatch);
            _watcher.Created += new FileSystemEventHandler(_watcher_Created);
            _watcher.Deleted += new FileSystemEventHandler(_watcher_Deleted);
            _watcher.Changed += new FileSystemEventHandler(_watcher_Changed);
            _watcher.Error += new ErrorEventHandler(_watcher_Error);

            Files = new FileList();
        }

        private void _watcher_Error(object sender, ErrorEventArgs e)
        {
            _tcs?.SetException(e.GetException());
            _tcs = null;
            IsWatching = false;
        }

        private void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            _context.Post((state) => Files.Add(new MediaFileViewModel(MediaFile.Create(e.FullPath))), null);
        }

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            _context.Post((state) => Files
                    .Where(f => f.MediaFile.FullPath == e.FullPath)
                    .ToList()
                    .ForEach(mf => mf.Refresh()), null);
        }

        private void _watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            _context.Post((state) => Files
                    .Where(f => f.MediaFile.FullPath == e.FullPath)
                    .ToList()
                    .ForEach(mf => Files.Remove(mf)), null);
        }

        public Task Startwatch()
        {
            if (_watcher.EnableRaisingEvents)
            {
                return _tcs.Task;
            }

            _watcher.EnableRaisingEvents = true;
            IsWatching = true;

            var filesInDirectory = new List<string>();
            foreach (var filePath in Directory.GetFiles(_pathToWatch, "*", SearchOption.AllDirectories))
            {
                var ext = Path.GetExtension(filePath).ToUpperInvariant();
                if (ext.EndsWith(".PDF") || ext.EndsWith(".PNG") || ext.EndsWith(".JPG"))
                {
                    filesInDirectory.Add(filePath);
                    var managingFile = Files.Where(mf => mf.MediaFile.FullPath == filePath).SingleOrDefault();
                    if (managingFile == null)
                    {
                        Files.Add(new MediaFileViewModel(MediaFile.Create(filePath)));
                    }
                }
            }

            foreach(var filePath in Files.Select(mf => mf.MediaFile.FullPath).Except(filesInDirectory).ToArray())
            {
                var managingFile = Files.Where(mf => mf.MediaFile.FullPath == filePath).Single();
                Files.Remove(managingFile);
            }

            _tcs = new TaskCompletionSource<object>();
            return _tcs.Task;            
        }

        public void Stopwatch()
        {
            _watcher.EnableRaisingEvents = false;
            _tcs?.SetResult(null);
            _tcs = null;
            IsWatching = false;
        }
    }
}
