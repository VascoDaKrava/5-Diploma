using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using System.Collections.Generic;


namespace RTDef.Units
{
    public sealed class UnitView : SelectableObjectBase, IClickableLeft, ICommandHolder
    {
        public List<ICommand> AwailableCommands => throw new System.NotImplementedException();
    }
}