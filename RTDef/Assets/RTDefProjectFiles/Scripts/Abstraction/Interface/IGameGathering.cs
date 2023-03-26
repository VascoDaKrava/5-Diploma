namespace RTDef.Abstraction
{
    public interface IGameGathering : IGameData
    {
        int Food { get; }
        int Wood { get; }
    }
}