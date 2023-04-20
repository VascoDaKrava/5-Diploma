namespace RTDef.Abstraction.Commands
{
    public interface IHarvestCommand : ICommand
    {
        IHarvestable Target { get; set; }
    }
}