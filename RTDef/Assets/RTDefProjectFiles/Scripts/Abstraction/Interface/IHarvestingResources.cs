namespace RTDef.Abstraction
{
    public interface IHarvestingResources : IGameData
    {
        int Food { get; }
        int Wood { get; }
    }
}