using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace TeamsPlc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "MAIN", "TeamsPlc", TypeComplexityEnum.Complex)]
	public partial class MAIN : Vortex.Connector.IVortexObject, IMAIN, IShadowMAIN, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		TeamsApp _App;
		public TeamsApp App
		{
			get
			{
				return _App;
			}
		}

		ITeamsApp IMAIN.App
		{
			get
			{
				return App;
			}
		}

		IShadowTeamsApp IShadowMAIN.App
		{
			get
			{
				return App;
			}
		}

		public void LazyOnlineToShadow()
		{
			App.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			App.LazyShadowToOnline();
		}

		public PlainMAIN CreatePlainerType()
		{
			var cloned = new PlainMAIN();
			cloned.App = App.CreatePlainerType();
			return cloned;
		}

		protected PlainMAIN CreatePlainerType(PlainMAIN cloned)
		{
			cloned.App = App.CreatePlainerType();
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

		public void FlushPlainToOnline(TeamsPlc.PlainMAIN source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(TeamsPlc.PlainMAIN source)
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

		public void FlushOnlineToPlain(TeamsPlc.PlainMAIN source)
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

		public MAIN(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
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
			_App = new TeamsApp(this, "", "App");
			AttributeName = "";
			parent.AddChild(this);
			parent.AddKid(this);
			PexConstructor(parent, readableTail, symbolTail);
		}

		public MAIN()
		{
			PexPreConstructorParameterless();
			_App = new TeamsApp();
			AttributeName = "";
			PexConstructorParameterless();
		}
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainMAIN
	{
		public void CopyPlainToCyclic(TeamsPlc.MAIN target)
		{
			App.CopyPlainToCyclic(target.App);
		}

		public void CopyPlainToCyclic(TeamsPlc.IMAIN target)
		{
			this.CopyPlainToCyclic((TeamsPlc.MAIN)target);
		}

		public void CopyPlainToShadow(TeamsPlc.MAIN target)
		{
			App.CopyPlainToShadow(target.App);
		}

		public void CopyPlainToShadow(TeamsPlc.IShadowMAIN target)
		{
			this.CopyPlainToShadow((TeamsPlc.MAIN)target);
		}

		public void CopyCyclicToPlain(TeamsPlc.MAIN source)
		{
			App.CopyCyclicToPlain(source.App);
		}

		public void CopyCyclicToPlain(TeamsPlc.IMAIN source)
		{
			this.CopyCyclicToPlain((TeamsPlc.MAIN)source);
		}

		public void CopyShadowToPlain(TeamsPlc.MAIN source)
		{
			App.CopyShadowToPlain(source.App);
		}

		public void CopyShadowToPlain(TeamsPlc.IShadowMAIN source)
		{
			this.CopyShadowToPlain((TeamsPlc.MAIN)source);
		}
	}
}