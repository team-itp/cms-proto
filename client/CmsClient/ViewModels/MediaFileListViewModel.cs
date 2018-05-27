using CmsClient.Models;
using System;
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
            _watcher.Renamed += new RenamedEventHandler(_watcher_Renamed);
            _watcher.Changed += new FileSystemEventHandler(_watcher_Changed);
            _watcher.Error += new ErrorEventHandler(_watcher_Error);

            Files = new FileList();
        }

        public static bool IsMediaFile(string path)
        {
            return MediaFile.IsMediaFile(path);
        }

        private void _watcher_Error(object sender, ErrorEventArgs e)
        {
            _tcs?.SetException(e.GetException());
            _tcs = null;
            IsWatching = false;
        }

        private void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            AddFileAsync(e.FullPath);
        }

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            UpdateFileAsync(e.FullPath, e.FullPath);
        }

        private void _watcher_Renamed(object sender, RenamedEventArgs e)
        {
            UpdateFileAsync(e.OldFullPath, e.FullPath);
        }

        private void _watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            DeleteFileAsync(e.FullPath);
        }

        private bool CanLockFile(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task AddFileAsync(string filePath)
        {
            if (!IsMediaFile(filePath))
            {
                return Task.CompletedTask;
            }

            return Task.Run(async () =>
            {
                await Task.Delay(200);

                while (File.Exists(filePath))
                {
                    if (CanLockFile(filePath))
                    {
                        _context.Post(state =>
                        {
                            var fileDeleted = Files.Where(f => f.MediaFile.FullPath == filePath).ToList();
                            fileDeleted.ForEach(mf =>
                            {
                                Files.Remove(mf);
                            });
                            Files.Add(new MediaFileViewModel(MediaFile.Create(filePath)));
                        }, null);
                        return;
                    }
                    else
                    {
                        await Task.Delay(100);
                    }
                }
            });
        }

        public Task UpdateFileAsync(string oldFilePath, string newFilePath)
        {
            if (!IsMediaFile(newFilePath))
            {
                return DeleteFileAsync(oldFilePath);
            }

            return Task.Run(async () =>
            {
                await Task.Delay(200);

                while (File.Exists(newFilePath))
                {
                    if (CanLockFile(newFilePath))
                    {
                        await DeleteFileAsync(oldFilePath);
                        _context.Post(state => Files.Add(new MediaFileViewModel(MediaFile.Create(newFilePath))), null);
                        return;
                    }
                    else
                    {
                        await Task.Delay(100);
                    }
                }
            });
        }

        public Task DeleteFileAsync(string filePath)
        {
            if (!IsMediaFile(filePath))
            {
                return Task.CompletedTask;
            }

            _context.Send(state =>
            {
                var fileDeleted = Files.Where(f => f.MediaFile.FullPath == filePath).ToList();
                fileDeleted.ForEach(mf =>
                {
                    Files.Remove(mf);
                });
            }, null);

            return Task.CompletedTask;
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
                if (IsMediaFile(filePath))
                {
                    filesInDirectory.Add(filePath);
                    var managingFile = Files.Where(mf => mf.MediaFile.FullPath == filePath).SingleOrDefault();
                    if (managingFile == null)
                    {
                        try
                        {
                            Files.Add(new MediaFileViewModel(MediaFile.Create(filePath)));
                        }
                        catch { }
                    }
                }
            }

            foreach (var filePath in Files.Select(mf => mf.MediaFile.FullPath).Except(filesInDirectory).ToArray())
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
