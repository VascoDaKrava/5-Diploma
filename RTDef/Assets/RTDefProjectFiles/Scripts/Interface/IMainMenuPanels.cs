using RTDef.Data.Text;
using RTDef.Menu;


namespace RTDef.Abstraction
{
    public interface IMainMenuPanels
    {
        InfoPanelView InfoPanel { get; }
        StartPanelView StartPanel { get; }
        OptionsPanelView OptionsPanel { get; }
        ProfilePanelView ProfilePanel { get; }
        MultiplayerPanelView MultiplayerPanel { get; }
        MainMenuTitles Titles { get; }
    }
}