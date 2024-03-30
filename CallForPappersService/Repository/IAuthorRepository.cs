namespace CallForPappersService.Repository
{
    public interface IAuthorRepository
    {
        bool AuthorExists(Guid authorId);
    }
}
