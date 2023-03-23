using UnityEditor;
using UnityEngine;


namespace RTDef.Data
{
    [CreateAssetMenu(fileName = "AllScenes", menuName = "Data/AllScenes")]
    public sealed class AllScenes : ScriptableObject
    {

        #region Properties

        [field: SerializeField] public SceneAsset MainMenuScene { get; private set; }
        [field: SerializeField] public SceneAsset SingleGameScene { get; private set; }
        [field: SerializeField] public SceneAsset MultiplayerScene { get; private set; }

        #endregion

    }
}