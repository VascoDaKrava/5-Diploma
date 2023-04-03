using RTDef.Enum;


namespace RTDef.Abstraction.Commands
{
    public struct StopCommand : IStopCommand
    {
        public CommandName CommandToStop { get; set; }
    }
}