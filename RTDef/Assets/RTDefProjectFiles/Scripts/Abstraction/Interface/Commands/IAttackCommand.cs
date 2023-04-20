namespace RTDef.Abstraction.Commands
{
    public interface IAttackCommand : ICommand
    {
        IAttackable AttackableTarget { get; set; }
    }
}