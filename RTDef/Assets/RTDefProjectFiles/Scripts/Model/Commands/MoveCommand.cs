using UnityEngine;


namespace RTDef.Abstraction.Commands
{
    public struct MoveCommand : IMoveCommand
    {
        public Vector3 Target { get; set; }
    }
}