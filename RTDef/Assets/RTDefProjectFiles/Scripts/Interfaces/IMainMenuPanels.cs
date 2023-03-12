using RTDef.Menu;


namespace RTDef.Abstraction
{
    public interface IMainMenuPanels
    {
        InfoPanelView InfoPanel { get; }
        StartPanelView StartPanel { get; }
        OptionsPanelView OptionsPanel { get; }
        LoginPanelView LoginPanel { get; }
        MultiplayerPanelView MultiplayerPanel { get; }
    }
}