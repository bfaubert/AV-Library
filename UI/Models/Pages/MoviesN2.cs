using N2;
using N2.Details;
using Dinamico.Models;

namespace UI.Models.Pages
{
    /// <summary>
    /// This class represents the data transfer object that encapsulates 
    /// the information used by the template.
    /// </summary>
    [PageDefinition("Movies")]
    [WithEditableTitle, WithEditableName]
    public class MoviesN2 : ContentPage
    {
        [EditableTextBox(Title = "My Sample String Property", ContainerName = "Content", SortOrder = 100)]
        public virtual string MySampleString { get; set; }
    }
}
