using System;

namespace TeamsPlc
{
	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainTeamsApp : Vortex.Connector.IPlain
	{
		TcoCore.PlainTcoTask _StartTheMachine;
		public TcoCore.PlainTcoTask StartTheMachine
		{
			get
			{
				return _StartTheMachine;
			}

			set
			{
				if (_StartTheMachine != value)
				{
					_StartTheMachine = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(StartTheMachine)));
				}
			}
		}

		TcoCore.PlainTcoTask _StopTheMachine;
		public TcoCore.PlainTcoTask StopTheMachine
		{
			get
			{
				return _StopTheMachine;
			}

			set
			{
				if (_StopTheMachine != value)
				{
					_StopTheMachine = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(StopTheMachine)));
				}
			}
		}

		System.Boolean _IsMachineRunning;
		public System.Boolean IsMachineRunning
		{
			get
			{
				return _IsMachineRunning;
			}

			set
			{
				if (_IsMachineRunning != value)
				{
					_IsMachineRunning = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(IsMachineRunning)));
				}
			}
		}

		System.String _MessageFromPlc;
		public System.String MessageFromPlc
		{
			get
			{
				return _MessageFromPlc;
			}

			set
			{
				if (_MessageFromPlc != value)
				{
					_MessageFromPlc = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(MessageFromPlc)));
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainTeamsApp()
		{
			_StartTheMachine = new TcoCore.PlainTcoTask();
			_StopTheMachine = new TcoCore.PlainTcoTask();
		}
	}
}