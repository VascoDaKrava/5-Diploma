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
        private bool _callCancel;
        private CommandName _currentCommand;

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

        public void CancelCommand()
        {
            _callCancel = true;
        }

        public void StartGetCommand(CommandName command)
        {
            _interactionEvents.OnRightDown += GetTarget;
            _dataRecieved = false;
            _callCancel = false;
            _currentCommand = command;

            WaitForDataAsync();
        }

        /// <summary>
        /// Wait for data to be received and invoke event OnCommandReady
        /// </summary>
        private async void WaitForDataAsync()
        {
            await Task.Run(() => { while (!_dataRecieved && !_callCancel) { }; });

            if (_callCancel)
            {
                return;
            }

            switch (_currentCommand)
            {
                case CommandName.Move:
                    OnCommandReady?.Invoke(new MoveCommand { Target = _interactionEvents.HitPoint });
                    break;

                case CommandName.Attack:
                    break;

                case CommandName.Gathering:
                    break;

                case CommandName.Build:
                    break;

                case CommandName.Produce:
                    break;

                case CommandName.Kill:
                    break;

                default:
                    throw new ArgumentException($"Unexpected command: {_currentCommand}");
            }
        }

        /// <summary>
        /// Check conditions to take target for command
        /// </summary>
        /// <param name="hit">RMB returned Object</param>
        private void GetTarget(IClickableRight hit)
        {
            switch (_currentCommand)
            {
                case CommandName.Move:
                    if (hit is GroundMarker)
                    {
                        _interactionEvents.OnRightDown -= GetTarget;
                        _dataRecieved = true;
                    }
                    break;

                case CommandName.Attack:

                    break;

                case CommandName.Gathering:
                    break;

                case CommandName.Build:
                    break;

                case CommandName.Produce:
                    break;

                case CommandName.Kill:
                    break;

                default:
                    throw new ArgumentException($"Unexpected command: {_currentCommand}");
            }
        }

        #endregion

    }
}