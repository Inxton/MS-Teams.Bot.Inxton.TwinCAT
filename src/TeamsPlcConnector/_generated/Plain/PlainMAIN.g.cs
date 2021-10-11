using System;

namespace TeamsPlc
{
	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainMAIN : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		PlainTeamsApp _App;
		public PlainTeamsApp App
		{
			get
			{
				return _App;
			}

			set
			{
				if (_App != value)
				{
					_App = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(App)));
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainMAIN()
		{
			_App = new PlainTeamsApp();
		}
	}
}