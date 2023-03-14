using UnityEngine;


namespace RTDef.Data.Text
{
    [CreateAssetMenu(fileName = "MainMenuTitles", menuName = "Data/MainMenuTitles")]
    public sealed class MainMenuTitles : ScriptableObject
    {
        [field: SerializeField] public Color NormalColor { get; private set; }
        [field: SerializeField] public Color ErrorColor { get; private set; }
        [field: SerializeField] public Color SuccessColor { get; private set; }

        [field: SerializeField] public string StartPanelNotLoggedInTitle { get; private set; }
        [field: SerializeField] public string StartPanelLoggedInTitle { get; private set; }
        [field: SerializeField] public string OptionsPanelTitle { get; private set; }
        [field: SerializeField] public string MultiplayerPanelTitle { get; private set; }
        [field: SerializeField] public string LoginPanelTitleLoggedIn { get; private set; }
        [field: SerializeField] public string LoginPanelTitleNotLoggedIn { get; private set; }
    }
}