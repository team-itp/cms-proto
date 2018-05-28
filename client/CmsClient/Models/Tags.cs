using System;
using System.Collections.Generic;
using System.Text;

namespace CmsClient.Models
{
    public enum SelectionType
    {
        Single,
        Multiple,
        Addable,
        Free
    }

    public class TagSelection
    {
        public string Title { get; set; }
        public SelectionType Type { get; set; }
        public IEnumerable<Tag> TagChoices { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public int TermId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }

        public Tag(string name) : this(-1, default(int), Convert.ToBase64String(Encoding.ASCII.GetBytes(name)), name)
        {
        }

        public Tag(int id, int termId, string slug, string name)
        {
            Id = id;
            TermId = termId;
            Slug = slug;
            Name = name;
        }

        public void UpdateId(int newId)
        {
            Id = newId;
        }
    }
}
