using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace TeamsPlc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "TeamsApp", "TeamsPlc", TypeComplexityEnum.Complex)]
	public partial class TeamsApp : Vortex.Connector.IVortexObject, ITeamsApp, IShadowTeamsApp, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		TcoCore.TcoTask _StartTheMachine;
		public TcoCore.TcoTask StartTheMachine
		{
			get
			{
				return _StartTheMachine;
			}
		}

		TcoCore.ITcoTask ITeamsApp.StartTheMachine
		{
			get
			{
				return StartTheMachine;
			}
		}

		TcoCore.IShadowTcoTask IShadowTeamsApp.StartTheMachine
		{
			get
			{
				return StartTheMachine;
			}
		}

		TcoCore.TcoTask _StopTheMachine;
		public TcoCore.TcoTask StopTheMachine
		{
			get
			{
				return _StopTheMachine;
			}
		}

		TcoCore.ITcoTask ITeamsApp.StopTheMachine
		{
			get
			{
				return StopTheMachine;
			}
		}

		TcoCore.IShadowTcoTask IShadowTeamsApp.StopTheMachine
		{
			get
			{
				return StopTheMachine;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerBool _IsMachineRunning;
		public Vortex.Connector.ValueTypes.OnlinerBool IsMachineRunning
		{
			get
			{
				return _IsMachineRunning;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineBool ITeamsApp.IsMachineRunning
		{
			get
			{
				return IsMachineRunning;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowBool IShadowTeamsApp.IsMachineRunning
		{
			get
			{
				return IsMachineRunning;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerString _MessageFromPlc;
		public Vortex.Connector.ValueTypes.OnlinerString MessageFromPlc
		{
			get
			{
				return _MessageFromPlc;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineString ITeamsApp.MessageFromPlc
		{
			get
			{
				return MessageFromPlc;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowString IShadowTeamsApp.MessageFromPlc
		{
			get
			{
				return MessageFromPlc;
			}
		}

		public void LazyOnlineToShadow()
		{
			StartTheMachine.LazyOnlineToShadow();
			StopTheMachine.LazyOnlineToShadow();
			IsMachineRunning.Shadow = IsMachineRunning.LastValue;
			MessageFromPlc.Shadow = MessageFromPlc.LastValue;
		}

		public void LazyShadowToOnline()
		{
			StartTheMachine.LazyShadowToOnline();
			StopTheMachine.LazyShadowToOnline();
			IsMachineRunning.Cyclic = IsMachineRunning.Shadow;
			MessageFromPlc.Cyclic = MessageFromPlc.Shadow;
		}

		public PlainTeamsApp CreatePlainerType()
		{
			var cloned = new PlainTeamsApp();
			cloned.StartTheMachine = StartTheMachine.CreatePlainerType();
			cloned.StopTheMachine = StopTheMachine.CreatePlainerType();
			return cloned;
		}

		protected PlainTeamsApp CreatePlainerType(PlainTeamsApp cloned)
		{
			cloned.StartTheMachine = StartTheMachine.CreatePlainerType();
			cloned.StopTheMachine = StopTheMachine.CreatePlainerType();
			return cloned;
		}

		partial void PexPreConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexPreConstructorParameterless();
		private System.Collections.Generic.List<Vortex.Connector.IVortexObject> @Children
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IVortexObject> @GetChildren()
		{
			return this.@Children;
		}

		public void AddChild(Vortex.Connector.IVortexObject vortexObject)
		{
			this.@Children.Add(vortexObject);
		}

		private System.Collections.Generic.List<Vortex.Connector.IVortexElement> Kids
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IVortexElement> GetKids()
		{
			return this.Kids;
		}

		public void AddKid(Vortex.Connector.IVortexElement vortexElement)
		{
			this.Kids.Add(vortexElement);
		}

		partial void PexConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexConstructorParameterless();
		protected Vortex.Connector.IVortexObject @Parent
		{
			get;
			set;
		}

		public Vortex.Connector.IVortexObject GetParent()
		{
			return this.@Parent;
		}

		private System.Collections.Generic.List<Vortex.Connector.IValueTag> @ValueTags
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IValueTag> GetValueTags()
		{
			return this.@ValueTags;
		}

		public void AddValueTag(Vortex.Connector.IValueTag valueTag)
		{
			this.@ValueTags.Add(valueTag);
		}

		protected Vortex.Connector.IConnector @Connector
		{
			get;
			set;
		}

		public Vortex.Connector.IConnector GetConnector()
		{
			return this.@Connector;
		}

		public void FlushPlainToOnline(TeamsPlc.PlainTeamsApp source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(TeamsPlc.PlainTeamsApp source)
		{
			source.CopyPlainToShadow(this);
		}

		public void FlushShadowToOnline()
		{
			this.LazyShadowToOnline();
			this.Write();
		}

		public void FlushOnlineToShadow()
		{
			this.Read();
			this.LazyOnlineToShadow();
		}

		public void FlushOnlineToPlain(TeamsPlc.PlainTeamsApp source)
		{
			this.Read();
			source.CopyCyclicToPlain(this);
		}

		protected System.String @SymbolTail
		{
			get;
			set;
		}

		public System.String GetSymbolTail()
		{
			return this.SymbolTail;
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

		public TeamsApp(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			this.Kids = new System.Collections.Generic.List<Vortex.Connector.IVortexElement>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			_StartTheMachine = new TcoCore.TcoTask(this, "", "StartTheMachine");
			_StopTheMachine = new TcoCore.TcoTask(this, "", "StopTheMachine");
			_IsMachineRunning = @Connector.Online.Adapter.CreateBOOL(this, "", "IsMachineRunning");
			_MessageFromPlc = @Connector.Online.Adapter.CreateSTRING(this, "", "MessageFromPlc");
			AttributeName = "";
			parent.AddChild(this);
			parent.AddKid(this);
			PexConstructor(parent, readableTail, symbolTail);
		}

		public TeamsApp()
		{
			PexPreConstructorParameterless();
			_StartTheMachine = new TcoCore.TcoTask();
			_StopTheMachine = new TcoCore.TcoTask();
			_IsMachineRunning = Vortex.Connector.IConnectorFactory.CreateBOOL();
			_MessageFromPlc = Vortex.Connector.IConnectorFactory.CreateSTRING();
			AttributeName = "";
			PexConstructorParameterless();
		}
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainTeamsApp
	{
		public void CopyPlainToCyclic(TeamsPlc.TeamsApp target)
		{
			StartTheMachine.CopyPlainToCyclic(target.StartTheMachine);
			StopTheMachine.CopyPlainToCyclic(target.StopTheMachine);
			target.IsMachineRunning.Cyclic = IsMachineRunning;
			target.MessageFromPlc.Cyclic = MessageFromPlc;
		}

		public void CopyPlainToCyclic(TeamsPlc.ITeamsApp target)
		{
			this.CopyPlainToCyclic((TeamsPlc.TeamsApp)target);
		}

		public void CopyPlainToShadow(TeamsPlc.TeamsApp target)
		{
			StartTheMachine.CopyPlainToShadow(target.StartTheMachine);
			StopTheMachine.CopyPlainToShadow(target.StopTheMachine);
			target.IsMachineRunning.Shadow = IsMachineRunning;
			target.MessageFromPlc.Shadow = MessageFromPlc;
		}

		public void CopyPlainToShadow(TeamsPlc.IShadowTeamsApp target)
		{
			this.CopyPlainToShadow((TeamsPlc.TeamsApp)target);
		}

		public void CopyCyclicToPlain(TeamsPlc.TeamsApp source)
		{
			StartTheMachine.CopyCyclicToPlain(source.StartTheMachine);
			StopTheMachine.CopyCyclicToPlain(source.StopTheMachine);
			IsMachineRunning = source.IsMachineRunning.LastValue;
			MessageFromPlc = source.MessageFromPlc.LastValue;
		}

		public void CopyCyclicToPlain(TeamsPlc.ITeamsApp source)
		{
			this.CopyCyclicToPlain((TeamsPlc.TeamsApp)source);
		}

		public void CopyShadowToPlain(TeamsPlc.TeamsApp source)
		{
			StartTheMachine.CopyShadowToPlain(source.StartTheMachine);
			StopTheMachine.CopyShadowToPlain(source.StopTheMachine);
			IsMachineRunning = source.IsMachineRunning.Shadow;
			MessageFromPlc = source.MessageFromPlc.Shadow;
		}

		public void CopyShadowToPlain(TeamsPlc.IShadowTeamsApp source)
		{
			this.CopyShadowToPlain((TeamsPlc.TeamsApp)source);
		}
	}
}