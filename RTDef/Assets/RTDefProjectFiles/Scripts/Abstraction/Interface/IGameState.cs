namespace RTDef.Abstraction
{
    public interface IGameState : IGameData
    {
        bool IsClientLoggedIn { get; }
        string ClientUserName { get; }
    }
}