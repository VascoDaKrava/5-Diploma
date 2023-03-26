using RTDef.Game.UI;


namespace RTDef.Abstraction
{
    public interface IInGamePanels : IGameData
    {
        GameTopPanelView GameTopPanelView { get; }
        GameBottomPanelView GameBottomPanelView { get; }
    }
}