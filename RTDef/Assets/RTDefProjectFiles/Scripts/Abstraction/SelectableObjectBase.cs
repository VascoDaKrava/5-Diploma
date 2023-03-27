using UnityEngine;


namespace RTDef.Abstraction
{
    public abstract class SelectableObjectBase : MonoBehaviour, IDataForPanel
    {

        #region Properties

        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int HealthMax { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }
        [field: SerializeField] public int Defence { get; private set; }
        [field: SerializeField] public int Range { get; private set; }

        #endregion

    }
}