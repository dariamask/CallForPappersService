namespace CallForPappersService.Repository
{
    public interface IAuthorRepository
    {
        Task<bool> AuthorExistsAsync (Guid authorId);
    }
}
