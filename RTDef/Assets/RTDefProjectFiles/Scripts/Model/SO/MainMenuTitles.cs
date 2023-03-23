using UnityEngine;


namespace RTDef.Data.Text
{
    [CreateAssetMenu(fileName = "MainMenuTitles", menuName = "Data/MainMenuTitles")]
    public sealed class MainMenuTitles : ScriptableObject
    {
        [field: SerializeField] public Color NormalColor { get; private set; }
        [field: SerializeField] public Color ErrorColor { get; private set; }
        [field: SerializeField] public Color SuccessColor { get; private set; }

        [field: SerializeField] public string StartPanelTitle { get; private set; }
        [field: SerializeField] public string StartPanelNotLoggedInMessage { get; private set; }
        [field: SerializeField] public string StartPanelLoggedInMessage { get; private set; }
        
        [field: SerializeField] public string OptionsPanelTitle { get; private set; }
        
        [field: SerializeField] public string MultiplayerPanelTitle { get; private set; }
        [field: SerializeField] public string MultiplayerPanelConnecting { get; private set; }
        [field: SerializeField] public string MultiplayerPanelCreateRoom { get; private set; }
        [field: SerializeField] public string MultiplayerPanelJoin { get; private set; }
        [field: SerializeField] public string MultiplayerPanelOtherStart { get; private set; }
        [field: SerializeField] public string MultiplayerPanelStart { get; private set; }

        [field: SerializeField] public string ProfilePanelTitle { get; private set; }
        [field: SerializeField] public string ProfilePanelLoggedInMessage { get; private set; }
        [field: SerializeField] public string ProfilePanelNotLoggedInMessage { get; private set; }
    }
}