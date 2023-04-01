using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using RTDef.Enum;
using System;
using System.Threading.Tasks;
using UnityEngine;


namespace RTDef.Game.Commands
{
    public sealed class CommandConcretizator : IDisposable
    {

        #region Events

        public event Action<ICommand> OnCommandReady;

        private bool _dataRecieved;

        #endregion


        #region Fields

        private readonly IInteractionsGet _interactionEvents;

        #endregion


        #region CodeLife

        public CommandConcretizator(IInteractionsGet interactionEvents)
        {
            _interactionEvents = interactionEvents;

        }

        public void Dispose()
        {

        }

        #endregion


        #region Methods

        public void StartGetCommand(CommandName command)
        {
            _interactionEvents.OnRightDown += GetDestinationPosition;
            _dataRecieved = false;

            Debug.Log("Before Async");
            WaitForDataAsync();
            Debug.Log("After Async");

            #region MyRegion

            //switch (command)
            //{
            //    case CommandName.None:
            //        break;

            //    case CommandName.Stop:
            //        break;

            //    case CommandName.Move:

            //        break;

            //    case CommandName.Attack:
            //        break;

            //    case CommandName.Gathering:
            //        break;

            //    case CommandName.Build:
            //        break;

            //    case CommandName.Produce:
            //        break;

            //    case CommandName.ProduceWorker:
            //        break;

            //    case CommandName.ProduceWarrior:
            //        break;

            //    case CommandName.ProduceArcher:
            //        break;

            //    case CommandName.BuildTower:
            //        break;

            //    case CommandName.Kill:
            //        break;

            //    default:
            //        break;
            //}

            #endregion

        }

        private async void WaitForDataAsync()
        {
            await Task.Run(() => { while (!_dataRecieved) { }; });
            OnCommandReady?.Invoke(new MoveCommand { Target = _interactionEvents.HitPoint });
        }

        private void GetDestinationPosition(IClickableRight hit)
        {
            if (hit is GroundMarker)
            {
                _interactionEvents.OnRightDown -= GetDestinationPosition;
                _dataRecieved = true;
            }
        }

        #endregion

    }
}