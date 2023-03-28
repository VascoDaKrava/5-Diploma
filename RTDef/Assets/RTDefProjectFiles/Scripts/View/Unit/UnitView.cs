using RTDef.Abstraction;
using RTDef.Abstraction.InputSystem;
using RTDef.Enum;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Units
{
    public sealed class UnitView : SelectableObjectBase, IClickableLeft, ICommandHolder
    {
        [SerializeField] private List<CommandName> _availableCommands;

        public SortedSet<CommandName> AwailableCommands { get; private set; }

        private void OnEnable()
        {
            AwailableCommands = new SortedSet<CommandName>(_availableCommands);
        }
    }
}