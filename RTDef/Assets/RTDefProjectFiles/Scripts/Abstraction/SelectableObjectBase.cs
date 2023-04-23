using UnityEngine;


namespace RTDef.Abstraction
{
    public abstract class SelectableObjectBase : MonoBehaviour, IInfoForPanel, IFaction
    {

        #region Properties

        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Health { get; private protected set; }
        [field: SerializeField] public int HealthMax { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }
        [field: SerializeField] public int Defence { get; private set; }
        [field: SerializeField] public int Range { get; private set; }
        [field: SerializeField] public int SecondsToHit { get; private set; }

        [field: SerializeField] public int FactionID { get; private set; }

        #endregion

    }
}