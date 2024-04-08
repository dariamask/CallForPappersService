namespace CallForPappersService_DAL.Repository
{
    public interface IAuthorRepository
    {
        Task<bool> AuthorExistsAsync (Guid authorId);
    }
}
