using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;
using TeamsPlcConnector.Properties;

[assembly: Vortex.Connector.Attributes.AssemblyPlcCounterPart("{\r\n  \"Types\": [\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"TeamsApp\",\r\n      \"Namespace\": \"TeamsPlc\",\r\n      \"TypeMetaInfo\": 4\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"MAIN\",\r\n      \"Namespace\": \"TeamsPlc\",\r\n      \"TypeMetaInfo\": 3\r\n    }\r\n  ],\r\n  \"Name\": \"TeamsPlc\",\r\n  \"Namespace\": \"TeamsPlc\"\r\n}")]
#pragma warning disable SA1402, CS1591, CS0108, CS0067
namespace TeamsPlc
{
	public partial class TeamsPlcTwinController : Vortex.Connector.ITwinController, ITeamsPlcTwinController, IShadowTeamsPlcTwinController
	{
		public string Symbol
		{
			get;
			protected set;
		}

		public string HumanReadable
		{
			get
			{
				return TeamsPlcTwinController.Translator.Translate(_humanReadable).Interpolate(this);
			}

			protected set
			{
				_humanReadable = value;
			}
		}

		protected string _humanReadable;
		MAIN _MAIN;
		public MAIN MAIN
		{
			get
			{
				return _MAIN;
			}
		}

		IMAIN ITeamsPlcTwinController.MAIN
		{
			get
			{
				return MAIN;
			}
		}

		IShadowMAIN IShadowTeamsPlcTwinController.MAIN
		{
			get
			{
				return MAIN;
			}
		}

		public void LazyOnlineToShadow()
		{
			MAIN.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			MAIN.LazyShadowToOnline();
		}

		public PlainTeamsPlcTwinController CreatePlainerType()
		{
			var cloned = new PlainTeamsPlcTwinController();
			cloned.MAIN = MAIN.CreatePlainerType();
			return cloned;
		}

		protected PlainTeamsPlcTwinController CreatePlainerType(PlainTeamsPlcTwinController cloned)
		{
			cloned.MAIN = MAIN.CreatePlainerType();
			return cloned;
		}

		public System.String AttributeName
		{
			get
			{
				return TeamsPlcTwinController.Translator.Translate(_AttributeName).Interpolate(this);
			}

			set
			{
				_AttributeName = value;
			}
		}

		private System.String _AttributeName
		{
			get;
			set;
		}

		public ITeamsPlcTwinController Online
		{
			get
			{
				return (ITeamsPlcTwinController)this;
			}
		}

		public IShadowTeamsPlcTwinController Shadow
		{
			get
			{
				return (IShadowTeamsPlcTwinController)this;
			}
		}

		public Vortex.Connector.IConnector Connector
		{
			get;
			set;
		}

		public TeamsPlcTwinController()
		{
			var adapter = new Vortex.Connector.ConnectorAdapter(typeof (DummyConnectorFactory));
			this.Connector = adapter.GetConnector(new object[]{});
			_MAIN = new MAIN(this.Connector, "", "MAIN");
		}

		public TeamsPlcTwinController(Vortex.Connector.ConnectorAdapter adapter, object[] parameters)
		{
			this.Connector = adapter.GetConnector(parameters);
			_MAIN = new MAIN(this.Connector, "", "MAIN");
		}

		public TeamsPlcTwinController(Vortex.Connector.ConnectorAdapter adapter)
		{
			this.Connector = adapter.GetConnector(adapter.Parameters);
			_MAIN = new MAIN(this.Connector, "", "MAIN");
		}

		public static string LocalizationDirectory
		{
			get;
			set;
		}

		private static Vortex.Localizations.Abstractions.ITranslator _translator
		{
			get;
			set;
		}

		internal static Vortex.Localizations.Abstractions.ITranslator Translator
		{
			get
			{
				if (_translator == null)
				{
					_translator = Vortex.Localizations.Abstractions.ITranslator.Get(typeof (Localizations));
				} return  _translator ; 

			}
		}
	}

	public partial interface ITeamsPlcTwinController
	{
		IMAIN MAIN
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		TeamsPlc.PlainTeamsPlcTwinController CreatePlainerType();
	}

	public partial interface IShadowTeamsPlcTwinController
	{
		IShadowMAIN MAIN
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		TeamsPlc.PlainTeamsPlcTwinController CreatePlainerType();
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainTeamsPlcTwinController : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		PlainMAIN _MAIN;
		public PlainMAIN MAIN
		{
			get
			{
				return _MAIN;
			}

			set
			{
				if (_MAIN != value)
				{
					_MAIN = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(MAIN)));
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainTeamsPlcTwinController()
		{
			_MAIN = new PlainMAIN();
		}
	}
}