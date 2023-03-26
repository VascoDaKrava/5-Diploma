using RTDef.Data.Text;
using RTDef.Menu;


namespace RTDef.Abstraction
{
    public interface IGameMainMenuPanels : IGame
    {
        InfoPanelController InfoPanelController { get; }
        InfoPanelView InfoPanel { get; }
        StartPanelView StartPanel { get; }
        OptionsPanelView OptionsPanel { get; }
        ProfilePanelView ProfilePanel { get; }
        MultiplayerPanelView MultiplayerPanel { get; }
        MainMenuTitles Titles { get; }
}
}