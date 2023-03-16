using System;
using UnityEngine;


namespace RTDef.Abstraction
{
    public abstract class MonoLifeCallBacks : MonoBehaviour
    {

        #region Fields

        private event Action _onEnable;

        #endregion


        #region Properties

        public event Action OnEnableEvent { add => _onEnable += value; remove => _onEnable -= value; }

        #endregion


        #region Mono

        private void OnEnable()
        {
            _onEnable?.Invoke();
        }

        #endregion

    }
}