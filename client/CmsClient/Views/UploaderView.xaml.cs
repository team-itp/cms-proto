﻿using CmsClient.Models;
using CmsClient.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CmsClient.Views
{
    /// <summary>
    /// UploaderView.xaml の相互作用ロジック
    /// </summary>
    public partial class UploaderView : UserControl
    {
        public static readonly RoutedCommand UploadCommand = new RoutedCommand("Upload", typeof(UploaderView));

        public UploaderView()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(UploadCommand, Upload, CanUpload));
        }

        private async void Upload(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as UploaderViewModel;
                if (vm != null)
                {
                    await vm.Upload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), (string)GetValue(Window.TitleProperty));
            }
        }

        private void CanUpload(object sender, CanExecuteRoutedEventArgs e)
        {
            var vm = DataContext as UploaderViewModel;
            if (vm != null)
            {
                e.CanExecute = vm.CanUpload();
            }
        }

        private void SelectTag(object sender, ExecutedRoutedEventArgs e)
        {
            var vm = DataContext as UploaderViewModel;
            if (vm != null)
            {
                var tag = TagCombo.SelectedItem as Tag;
                if (tag == null && !string.IsNullOrEmpty(TagCombo.Text))
                {
                    tag = new Tag(TagCombo.Text);
                    TagCombo.Text = string.Empty;
                }
                if (tag != null)
                {
                    vm.SelectedTags.Add(tag);
                }
            }
        }

        private void TagCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var vm = DataContext as UploaderViewModel;
                if (vm != null)
                {
                    var tag = TagCombo.SelectedItem as Tag;
                    if (tag == null && !string.IsNullOrEmpty(TagCombo.Text))
                    {
                        tag = new Tag(TagCombo.Text);
                        TagCombo.Text = string.Empty;
                    }
                    if (tag != null)
                    {
                        vm.SelectedTags.Add(tag);
                    }
                }
            }
        }

        private void TagCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = DataContext as UploaderViewModel;
            if (vm != null)
            {
                if (e.AddedItems.Count > 0)
                {
                    foreach (var item in e.AddedItems)
                    {
                        var tag = item as Tag;
                        if (tag != null)
                        {
                            vm.SelectedTags.Add(tag);
                        }
                    }
                }
            }

        }
    }
}
