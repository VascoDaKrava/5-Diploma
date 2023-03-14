namespace RTDef.Abstraction
{
    public interface IGameState
    {
        bool IsClientLoggedIn { get; }
        string ClientUserName { get; }
    }
}