namespace RTDef.Abstraction.Commands
{
    public struct HarvestCommand : IHarvestCommand
    {
        public IHarvestable Target { get; set; }
    }
}