using RTDef.Abstraction;
using RTDef.Abstraction.Commands;
using RTDef.Abstraction.InputSystem;
using RTDef.Enum;
using System;
using System.Threading.Tasks;


namespace RTDef.Game.Commands
{
    public sealed class CommandConcretizator
    {

        #region Events

        public event Action<ICommand> OnCommandReady;

        #endregion


        #region Fields

        private readonly IInteractionsGet _interactionEvents;
        private bool _dataRecieved;
        private bool _callCancel;
        private CommandName _currentCommand;
        private IHarvestable _harvestable;
        private IAttackable _attackable;

        #endregion


        #region CodeLife

        public CommandConcretizator(IInteractionsGet interactionEvents)
        {
            _interactionEvents = interactionEvents;
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
            _harvestable = default;
            _attackable = default;
            _currentCommand = command;

            // For commands without target/concretization
            if (command == CommandName.Kill)
            {
                _interactionEvents.OnRightDown -= GetTarget;
                _dataRecieved = true;
            }

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
                    OnCommandReady?.Invoke(new AttackCommand { AttackableTarget = _attackable });
                    break;

                case CommandName.Harvest:
                    OnCommandReady?.Invoke(new HarvestCommand { Target = _harvestable });
                    break;

                case CommandName.Kill:
                    OnCommandReady?.Invoke(new KillCommand { });
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
                    if (hit is IAttackable attackable)
                    {
                        _interactionEvents.OnRightDown -= GetTarget;
                        _attackable = attackable;
                        _dataRecieved = true;
                    }
                    break;

                case CommandName.Harvest:
                    if (hit is IHarvestable harvestable)
                    {
                        _interactionEvents.OnRightDown -= GetTarget;
                        _harvestable = harvestable;
                        _dataRecieved = true;
                    }
                    break;

                default:
                    throw new ArgumentException($"Unexpected command: {_currentCommand}");
            }
        }

        #endregion

    }
}