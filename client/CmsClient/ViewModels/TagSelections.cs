using CmsClient.Models;
using System;
using System.Collections.ObjectModel;

namespace CmsClient.ViewModels
{
    public abstract class TagSelectionViewModel : ViewModelBase
    {
        private TagSelection _selection;

        public TagSelectionViewModel(TagSelection selection)
        {
            _selection = selection;
        }

        public ObservableCollection<Tag> SelectedTags { get; set; }

        public static TagSelectionViewModel Create(TagSelection s)
        {
            switch (s.Type)
            {
                case SelectionType.Single:
                    return new SingleTagSeltionViewModel(s);
                case SelectionType.Multiple:
                    return new MultipleTagSelectionViewModel(s);
                case SelectionType.Addable:
                    return new AddableTagSelectionViewModel(s);
                case SelectionType.Free:
                    return new FreeTagSelectionViewModel(s);
            }
            throw new ArgumentException();
        }
    }

    public class SingleTagSeltionViewModel : TagSelectionViewModel
    {
        public SingleTagSeltionViewModel(TagSelection selection) : base(selection)
        {
        }
    }

    public class MultipleTagSelectionViewModel : TagSelectionViewModel
    {
        public MultipleTagSelectionViewModel(TagSelection selection) : base(selection)
        {
        }
    }

    public class AddableTagSelectionViewModel : TagSelectionViewModel
    {
        public AddableTagSelectionViewModel(TagSelection selection) : base(selection)
        {
        }
    }

    public class FreeTagSelectionViewModel : TagSelectionViewModel
    {
        public FreeTagSelectionViewModel(TagSelection selection) : base(selection)
        {
        }
    }
}
