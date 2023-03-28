using RTDef.Abstraction;
using UnityEngine;


namespace RTDef.Game.UI
{
    public sealed class GameBottomPanelView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private GameBottomInfoView _infoView;
        [SerializeField] private GameBottomCommandView _commandsView;

        #endregion


        #region Methods

        public void ShowContent(IDataForPanel content)
        {
            if (content is IInfoForPanel info)
            {
                _infoView.SetTitle(info.Image, info.Name, info.Health, info.HealthMax);
                _infoView.SetCharacteristics(info.Attack, info.Defence, info.Range);
                _infoView.gameObject.SetActive(true);
            }
            else
            {
                _infoView.gameObject.SetActive(false);
            }

            if (content is ICommandHolder commandHolder)
            {
                _commandsView.ShowCommands(commandHolder.AwailableCommands);
                _commandsView.gameObject.SetActive(true);
            }
            else
            {
                _commandsView.gameObject.SetActive(false);
            }
        }

        #endregion

    }
}