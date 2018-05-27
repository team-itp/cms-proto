﻿using CmsClient.Models;
using CmsClient.Properties;
using CmsClient.Services;
using System;
using System.Collections.Generic;

namespace CmsClient.ViewModels
{
    public delegate void InitialSettingCompletedCallback();
    public delegate void InitialSettingCanceledCallback();
    public delegate void InitialSettingBackHandler();

    public class InitialSettingViewModel : ViewModelBase
    {
        private InitialSettingCompletedCallback _completedCallback;
        private InitialSettingCanceledCallback _canceledCallback;
        private ViewModelBase _currentView;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public Stack<ViewModelBase> _stack { get; set; }

        public InitialSettingViewModel(InitialSettingCompletedCallback completedCallback, InitialSettingCanceledCallback canceledCallback)
        {
            _completedCallback = completedCallback;
            _canceledCallback = canceledCallback;
            _stack = new Stack<ViewModelBase>();

            NavigateTo(new LoginViewModel(new LoginService(), LoggedIn, Back));
        }

        private void NavigateTo(ViewModelBase vm)
        {
            if (CurrentView != null)
            {
                _stack.Push(CurrentView);
            }
            CurrentView = vm;
        }

        private void Back()
        {
            if (_stack.Count == 0)
            {
                _canceledCallback.Invoke();
                return;
            }
            CurrentView = _stack.Pop();
        }

        private void LoggedIn(LoginCredential credential)
        {
            Settings.Default.UserId = credential.UserId;
            Settings.Default.PasswordHash = credential.PasswordHash;
            Settings.Default.Save();

            var vm = new SelectWatchDirectoryViewModel(WatchDirectorySelected, Back);
            vm.PathToWatch = Settings.Default.DirectoryToWatch;
            NavigateTo(vm);

        }

        private void WatchDirectorySelected(string pathToWatch)
        {
            Settings.Default.DirectoryToWatch = pathToWatch;
            Settings.Default.Save();
            _completedCallback.Invoke();
        }
    }
}
