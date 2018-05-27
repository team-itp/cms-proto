using CmsClient.Properties;
using System;
using System.ComponentModel;

namespace CmsClient.ViewModels
{
    public delegate void DirectorySelectedCallback(string pathToWatch);

    public class SelectWatchDirectoryViewModel : ViewModelBase, IDataErrorInfo
    {
        private DirectorySelectedCallback _directorySelectedCallback;
        private InitialSettingBackHandler _backHandler;
        private string _pathToWatch;


        public string PathToWatch
        {
            get => _pathToWatch;
            set
            {
                _pathToWatch = value;
                OnPropertyChanged(nameof(PathToWatch));
                HasErrorUpdated();
            }
        }
        public override bool HasError
        {
            get
            {
                return !string.IsNullOrEmpty(Verify(nameof(PathToWatch)));
            }
        }

        public SelectWatchDirectoryViewModel(DirectorySelectedCallback directorySelectedCallback, InitialSettingBackHandler backHandler)
        {
            _directorySelectedCallback = directorySelectedCallback;
            _backHandler = backHandler;
        }

        protected override string Verify(string columnName)
        {
            switch (columnName)
            {
                case nameof(PathToWatch):
                    if (string.IsNullOrWhiteSpace(PathToWatch))
                    {
                        return Resources.PATH_TO_WATCH_IS_EMPTY;
                    }
                    return string.Empty;
                default:
                    return null;
            }
        }

        public bool CanDone()
        {
            return !HasError;
        }

        public void Done()
        {
            if (HasError)
            {
                throw new InvalidOperationException();
            }

            _directorySelectedCallback.Invoke(PathToWatch);
        }

        public void Cancel()
        {
            _backHandler.Invoke();
        }
    }
}