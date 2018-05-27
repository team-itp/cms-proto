using CmsClient.Models;
using CmsClient.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WP = WordPressPCL;

namespace CmsClient.ViewModels
{
    public class UploaderViewModel : ViewModelBase
    {
        public class MediaFilesCollection : ObservableCollection<MediaFile> { }
        public class TagSelectionCollection : ObservableCollection<TagSelectionViewModel>
        {
            public IEnumerable<Tag> SelectedTags
            {
                get
                {
                    return this.SelectMany(ts => ts.SelectedTags);
                }
            }
        }

        public TagSelectionCollection TagSelections { get; }
        public MediaFilesCollection SelectedMediaFiles { get; }

        public bool CanExecuteUpload { get; private set; }
        public bool IsUploading { get; private set;}

        public bool IsInitialized = false;

        public UploaderViewModel()
        {
            TagSelections = new TagSelectionCollection();
            SelectedMediaFiles = new MediaFilesCollection();

            Task.Run(async () =>
            {
                try
                {
                    var selection = await HttpHelper.GetRequest<List<TagSelection>>(new Uri("http://localhost/wp-json/cms/v1/special-tags"));
                    UpdateSelection(selection);
                    IsInitialized = true;
                }
                catch (Exception)
                {
                    // TODO エラーハンドリング
                    throw;
                }
            });
        }

        private void UpdateSelection(List<TagSelection> selection)
        {
            selection.ForEach(s => TagSelections.Add(TagSelectionViewModel.Create(s)));
        }

        public void SelectFile(MediaFile file)
        {
            var index = SelectedMediaFiles.IndexOf(file);
            if (index < 0)
            {
                SelectedMediaFiles.Add(file);
            }
        }

        public async Task ExecuteUpload()
        {
            IsUploading = true;
            var tags = TagSelections.SelectedTags.Select(st => st.TermId).ToArray();

            foreach (var file in this.SelectedMediaFiles)
            {
                var newPost = new WP.Models.Post();
                newPost.Title = new WP.Models.Title(file.Name);
                newPost.Content = new WP.Models.Content(file.Name);
                newPost.Tags = this.TagSelections.SelectedTags.Select(st => st.TermId).ToArray();
                var wpClient = new WP.WordPressClient("http://localhost/wp-json");
                var post = await wpClient.Posts.Create(newPost);
            }
            IsUploading = false;
        }
    }
}
