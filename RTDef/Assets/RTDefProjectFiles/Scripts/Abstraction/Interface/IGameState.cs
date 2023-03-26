namespace RTDef.Abstraction
{
    public interface IGameState : IGame
    {
        bool IsClientLoggedIn { get; }
        string ClientUserName { get; }
    }
}