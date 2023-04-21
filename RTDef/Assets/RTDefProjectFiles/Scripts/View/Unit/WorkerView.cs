using UnityEngine;


namespace RTDef.Units
{
    public sealed class WorkerView : UnitView
    {

        #region Properties

        [field: SerializeField, Header("Worker data"), Space] public Transform Basket { get; private set; }
        [field: SerializeField] public Transform WoodLogPack { get; private set; }
        [field: SerializeField] public Transform Axe { get; private set; }
        [field: SerializeField] public Transform Apple { get; private set; }

        #endregion


        #region Mono

        private void Start()
        {
            HideAllProps();
        }

        #endregion


        #region Methods

        public void HideAllProps()
        {
            Basket.gameObject.SetActive(false);
            WoodLogPack.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Apple.gameObject.SetActive(false);
        }

        #endregion

    }
}