using RTDef.Data;
using RTDef.Data.InputSystem;
using System;
using UnityEngine;


namespace RTDef.Inputsystem
{
    public sealed class KeyboardInteraction : MonoBehaviour
    {

        #region Fields

        [SerializeField] private InteractionEvents _interactionEvents;
        [SerializeField] private InputSettings _inputSettings;

        #endregion


        #region Mono

        private void Update()
        {
            if (Math.Abs(Input.GetAxis(_inputSettings.AxisHorizontal)) > 0.0f)
            {
                _interactionEvents.OnHorizontalSetAndInvoke = Input.GetAxis(_inputSettings.AxisHorizontal);
            }

            if (Math.Abs(Input.GetAxis(_inputSettings.AxisVertical)) > 0.0f)
            {
                _interactionEvents.OnVerticalSetAndInvoke = Input.GetAxis(_inputSettings.AxisVertical);
            }
        }

        #endregion

    }
}