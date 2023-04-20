namespace RTDef.Abstraction.Commands
{
    public struct AttackCommand : IAttackCommand
    {
        public IAttackable AttackableTarget { get; set; }
    }
}