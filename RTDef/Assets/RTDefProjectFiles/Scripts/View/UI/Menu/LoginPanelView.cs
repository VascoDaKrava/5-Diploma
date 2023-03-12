using RTDef.Abstraction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace RTDef.Menu
{
    public sealed class LoginPanelView : MonoLifeCallBacks
    {

        #region Properties

        [field: SerializeField] public Toggle RegistrationToggle { get; private set; }
        [field: SerializeField] public TMP_InputField LoginInputField { get; private set; }
        [field: SerializeField] public TMP_InputField PasswordInputField { get; private set; }
        [field: SerializeField] public TMP_InputField EmailInputField { get; private set; }
        [field: SerializeField] public TMP_Text ActionButtonText { get; private set; }
        [field: SerializeField] public Button ActionButton { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }

        #endregion

    }
}