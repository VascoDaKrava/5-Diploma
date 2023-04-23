using RTDef.Game.UI;
using UnityEngine;


namespace RTDef.AI
{
    public sealed class AI_Regenerator : MonoBehaviour
    {

        #region Fields

        [SerializeField] private GameBottomInfoView _gameBottomInfo;

        [SerializeField] private AI_TargetSelector _enemyPrefab;
        [SerializeField] private float _timeToNewEnemy = 60.0f;
        private float _timeElapsed = 30.0f;

        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _enemyContainer;

        #endregion


        #region Mono

        private void Update()
        {
            //if ()

            _timeElapsed -= Time.deltaTime;

            if (_timeElapsed < 0.0f)
            {
                _timeElapsed = _timeToNewEnemy;
                CreateNewEnemy();
            }
        }

        #endregion


        #region Methods

        private void CreateNewEnemy()
        {
            var newEnemy = Instantiate(_enemyPrefab, _startPosition.position, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f), _enemyContainer);
            newEnemy._infoView = _gameBottomInfo;
        }

        #endregion

    }
}