using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class TagsExceptionMessageOnEnglish: ITagsExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Tag after add not found!";

        public string NotFound => "Tag not found!";

        public string NotFoundById(int id)
        {
            return $"Tag with id { id } not found! Perhaps item with entered id does not exist!";
        }

        public string UnableToDelete(int id)
        {
            return $"Unable to delete tag! Perhaps item with entered id { id } does not exist.";
        }
    }
}
