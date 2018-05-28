using CmsClient.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CmsClient.Views
{
    /// <summary>
    /// TagListView.xaml の相互作用ロジック
    /// </summary>
    public partial class TagListView : ItemsControl
    {
        public TagListView()
        {
            InitializeComponent();
        }

        private void Chip_DeleteClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var chip = sender as MaterialDesignThemes.Wpf.Chip;
            var tag = chip.DataContext as Tag;
            var collection = ItemsSource as ICollection<Tag>;
            collection.Remove(tag);
        }
    }
}
