namespace CallForPappersService.Interfaces
{
    public interface IAuthorRepository
    {
        bool AuthorExists(Guid authorId);
    }
}
