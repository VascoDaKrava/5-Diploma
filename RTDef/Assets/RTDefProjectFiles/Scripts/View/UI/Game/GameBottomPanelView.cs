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
            if (content == null)
            {
                _infoView.gameObject.SetActive(false);
                _commandsView.gameObject.SetActive(false);
                return;
            }

            _infoView.SetTitle(content.Image, content.Name, content.Health, content.HealthMax);
            _infoView.SetCharacteristics(content.Attack, content.Defence, content.Range);
            _infoView.gameObject.SetActive(true);
        }

        #endregion

    }
}