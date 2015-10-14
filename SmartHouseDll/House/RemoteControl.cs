using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHouseDll
{
    [Serializable]
    public class RemoteControl
    {
        private ICommand _command;
        private  IReader _reader;
        private  ICollection<IWriter> _writers; 
        private readonly Dictionary<string, ICommand> _commands;

        public RemoteControl(IReader reader, ICollection<IWriter> writers)
        {
            _reader = reader;
            _writers = writers;
            _commands = new Dictionary<string, ICommand>();
            CreateCommand();
        }

        public IReader Reader
        {
            get { return _reader; } 
        }

        public Dictionary<string, ICommand> Commands
        {
            get { return _commands; }
        }

        public void ReadCommand()
        {
            _reader.Read();
        }
        public void Write()
        {
            foreach (IWriter writer in _writers)
            {
                writer.Write(_reader);
            }
        }
        public void PushButton()
        {

            if (_reader.CommandData != null)
            {
                if (_commands.ContainsKey(_reader.CommandData))
                {
                    _command = _commands[_reader.CommandData];

                    try
                    {
                        _command.Execute(_reader);                        
                    }
                    catch (Exception exception)
                    {
                        _reader.Help(this, exception.Message);
                    }
                }
                else
                {
                    _reader.Help(this, "Неправильно введена команда!");
                }
            }
            else
            {
                _reader.Help(this, null);
            }
        }


        public void AddCommand(ICommand command)
        {
            if (!_commands.ContainsKey(command.Name))
            {
                _commands.Add(command.Name, command);
            }
            else
            {
                throw new Exception("Команда с таким именем уже существует");
            }
        }
        public void DeleteCommand(ICommand command)
        {
            if (_commands.ContainsKey(command.Name))
            {
                _commands.Remove(command.Name);
            }
        }

        public void ClearDataCommand()
        {
            _reader.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int lenght = 0;
            foreach (var buttonId in _commands.Values)
            {
                lenght = 15 - buttonId.Name.Length;
                sb.AppendFormat("{0} {1}- {2}\n", buttonId.Name, new string(' ', lenght), buttonId.Inform);
            }

            return sb.ToString();
        }

        private void CreateCommand()
        {
            AddCommand(new OnCommand());
            AddCommand(new OffCommand());
            AddCommand(new IncrementLightCommand());
            AddCommand(new DecrementLightCommand());
            AddCommand(new IncrementVolumeCommand());
            AddCommand(new DecrementVolumeCommand());
            AddCommand(new IncremenTemperCommand());
            AddCommand(new DecrementTemperCommand());
            AddCommand(new CinemaDvdCommand());
            AddCommand(new ClimatAutoCommand());
            AddCommand(new ClimatConditionerCommand());
            AddCommand(new ClimatHeatingCommand());
            AddCommand(new ClimatHumidifierCommand());

            AddCommand(new AddRoomCommand());

            AddCommand(new AddClimatControlCommand());
            AddCommand(new AddConditionerCommand());
            AddCommand(new AddDVDPlayerCommand());
            AddCommand(new AddHeatingCommand());
            AddCommand(new AddHouseCinemaCommand());
            AddCommand(new AddHumidifierCommand());
            AddCommand(new AddLampCommand());
            AddCommand(new AddTvCommand());

            AddCommand(new DeleteRoomCommand());
            AddCommand(new DeleteDeviceCommand());

        }
    }

}