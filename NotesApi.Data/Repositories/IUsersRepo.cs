namespace NotesApi.Data.Repositories
{
    public interface IUsersRepo
    {
        UserEntity AddUser(UserEntity newUserEntity);
        UserEntity GetByEmail(string email);
    }
}