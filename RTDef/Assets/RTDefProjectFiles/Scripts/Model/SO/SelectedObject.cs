using RTDef.Abstraction;
using RTDef.Model;
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

            if (selectableObject != null)
            {
                if (selectableObject.TryGetComponent<Highlighter>(out var newSelection))
                {
                    newSelection.Highlight = true;
                }
            }

            if (CurrentSelected != null)
            {
                if (CurrentSelected.TryGetComponent<Highlighter>(out var oldSelection))
                {
                    oldSelection.Highlight = false;
                }
            }

            OnSelectedChange?.Invoke(selectableObject);
            CurrentSelected = selectableObject;
        }

        #endregion

    }
}