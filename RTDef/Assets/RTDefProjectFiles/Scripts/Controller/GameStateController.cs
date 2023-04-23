using RTDef.Data;
using RTDef.Units;
using System.Collections.Generic;
using UnityEngine;


namespace RTDef.Game
{
    public sealed class GameStateController : MonoBehaviour
    {

        #region Fields

        [SerializeField] private GameObject _gameFinishPanel;
        [SerializeField] private GameObject _winTXT;
        [SerializeField] private GameObject _loseTXT;

        [SerializeField] public FactionData FactionData;

        [SerializeField] private List<UnitView> _firstPlayerUnits;
        [SerializeField] private List<UnitView> _secondPlayerUnits;

        #endregion


        #region Mono

        private void OnEnable()
        {
            foreach (var unit in _firstPlayerUnits)
            {
                unit.OnDie += OnUnitDieHandler;
            }

            foreach (var unit in _secondPlayerUnits)
            {
                unit.OnDie += OnUnitDieHandler;
            }
        }

        private void OnDisable()
        {
            foreach (var unit in _firstPlayerUnits)
            {
                unit.OnDie -= OnUnitDieHandler;
            }

            foreach (var unit in _secondPlayerUnits)
            {
                unit.OnDie -= OnUnitDieHandler;
            }
        }

        #endregion


        #region Methods

        private void OnUnitDieHandler(UnitView attackable)
        {
            if (_firstPlayerUnits.Remove(attackable))
            {
                CheckConditions(_firstPlayerUnits, 1);
                Debug.Log("First player -1");
            }
            else
            {
                if (_secondPlayerUnits.Remove(attackable))
                {
                    CheckConditions(_secondPlayerUnits, 2);
                    Debug.Log("Second player -1");
                }
                else
                {
                    throw new System.Exception($"GameStateController : cann`t find {attackable} to calculate GameState");
                }
            }
        }

        private void CheckConditions(List<UnitView> units, int playerID)
        {
            if (units.Count == 0)
            {
                if (FactionData.FactionID == playerID)
                {
                    _winTXT.SetActive(false);
                    _loseTXT.SetActive(true);
                    _gameFinishPanel.SetActive(true);
                }
                else
                {
                    _winTXT.SetActive(true);
                    _loseTXT.SetActive(false);
                    _gameFinishPanel.SetActive(true);
                }

                Debug.LogWarning("Load main menu");
            }
        }

        #endregion

    }
}