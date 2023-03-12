using UnityEngine;


namespace RTDef.Data.Text
{
    [CreateAssetMenu(fileName = "MainMenuTitles", menuName = "Data/MainMenuTitles")]
    public sealed class MainMenuTitles : ScriptableObject
    {
        [field: SerializeField] public string StartPanelNoLoginTitle { get; private set; }
        [field: SerializeField] public string OptionsPanelTitle { get; private set; }
    }
}