using CmsClient.Models;
using CmsClient.Properties;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP = WordPressPCL;

namespace CmsClient.ViewModels
{
    public class UploaderViewModel : ViewModelBase
    {
        public class MediaFilesCollection : ObservableCollection<MediaFile> { }
        public class TagsCollection : ObservableCollection<Tag> { }

        public MediaFilesCollection SelectedMediaFiles { get; }

        public TagsCollection ProjectChoices { get; set; }
        public Tag Project { get; set; }
        public TagsCollection TagChoices { get; set; }
        public TagsCollection SelectedTags { get; set; }

        private static WP.WordPressClient wpClient = new WP.WordPressClient("http://localhost/wp-json");
        
        public UploaderViewModel()
        {
            SelectedMediaFiles = new MediaFilesCollection();
            SelectedTags = new TagsCollection();
            ProjectChoices = new TagsCollection();
            ProjectChoices.Add(new Tag("案件1"));
            ProjectChoices.Add(new Tag("案件2"));
            ProjectChoices.Add(new Tag("案件3"));

            TagChoices = new TagsCollection();
            TagChoices.Add(new Tag("フリーのタグ1"));
            TagChoices.Add(new Tag("フリーのタグ2"));
            TagChoices.Add(new Tag("フリーのタグ3"));
        }

        public void SelectFile(MediaFile file)
        {
            var index = SelectedMediaFiles.IndexOf(file);
            if (index < 0)
            {
                SelectedMediaFiles.Add(file);
            }
        }

        public async Task Upload()
        {
            var userId = Settings.Default.UserId;
            var password = Settings.Default.PasswordHash;
            await wpClient.RequestJWToken(userId, password);
            foreach (var t in SelectedTags
                .Where(tag => tag.Id == -1)
                .ToList())
            {
                var createdTag = await wpClient.Tags.Create(new WP.Models.Tag(t.Name));
                t.UpdateId(createdTag.Id);
            }
            
            var tags = SelectedTags.Select(st => st.TermId).ToArray();
            foreach (var file in this.SelectedMediaFiles)
            {
                var newPost = new WP.Models.Post();
                newPost.Title = new WP.Models.Title(file.Name);
                newPost.Content = new WP.Models.Content(file.Name);
                newPost.Tags = this.SelectedTags.Select(st => st.TermId).ToArray();
                var post = await wpClient.Posts.Create(newPost);
            }
        }

        public bool CanUpload()
        {
            return SelectedMediaFiles.Any();
        }
    }
}
