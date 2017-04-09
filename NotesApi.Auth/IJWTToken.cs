namespace NotesApi.Auth
{
    public interface IJWTToken
    {
        string Build(Payload payload);
        Payload Parse(string token);
    }
}