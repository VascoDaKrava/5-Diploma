using RTDef.Data;
using UnityEngine;


namespace RTDef.Game
{
    public sealed class GameRoot : MonoBehaviour
    {

        #region Fields

        [SerializeField] private InteractionEvents _interactionEvents;

        #endregion


        #region Properties


        #endregion

        private void OnEnable()
        {
            _interactionEvents.OnLeftDown += (obj) => Debug.Log("L -> " + obj);
            _interactionEvents.OnRightDown += (obj) => Debug.Log("R -> " + obj);
        }

    }
}