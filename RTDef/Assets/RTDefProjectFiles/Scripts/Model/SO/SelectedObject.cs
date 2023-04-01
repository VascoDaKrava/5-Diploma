using RTDef.Abstraction;
using System;
using UnityEngine;


namespace RTDef.Data
{
    [CreateAssetMenu(fileName = "SelectedObject", menuName = "Data/SelectedObject")]
    public sealed class SelectedObject : ScriptableObject
    {

        #region Events

        public event Action<SelectableObjectBase> OnSelectedChange;

        #endregion


        #region Properties

        public SelectableObjectBase CurrentSelected { get; private set; }

        #endregion


        #region Methods

        public void SelectedChange(SelectableObjectBase selectableObject)
        {
            if (selectableObject?.GetHashCode() == CurrentSelected?.GetHashCode())
            {
                return;
            }

            OnSelectedChange?.Invoke(selectableObject);
            CurrentSelected = selectableObject;
        }

        #endregion

    }
}