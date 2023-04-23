using RTDef.Abstraction;
using UnityEngine;


namespace RTDef.Data
{
    [CreateAssetMenu(fileName = "FactionData", menuName = "Data/FactionData")]
    public sealed class FactionData : ScriptableObject, IFaction
    {
        [field: SerializeField] public int FactionID { get; private set; }
    }
}