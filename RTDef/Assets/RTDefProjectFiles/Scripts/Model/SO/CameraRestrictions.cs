using UnityEngine;


namespace RTDef.Data.Camera
{
    [CreateAssetMenu(fileName = "CameraRestrictions", menuName = "Data/CameraRestrictions")]
    public sealed class CameraRestrictions : ScriptableObject
    {

        #region Properties

        [field: SerializeField] public float Zmin { get; private set; }
        [field: SerializeField] public float Zmax { get; private set; }
        [field: SerializeField] public float Xmin { get; private set; }
        [field: SerializeField] public float Xmax { get; private set; }
        [field: SerializeField] public float ZoomHeightMin { get; private set; }
        [field: SerializeField] public float ZoomHeightMax { get; private set; }
        [field: SerializeField] public float MooveSpeed { get; private set; }
        [field: SerializeField] public float ZoomSpeed { get; private set; }

        #endregion

    }
}