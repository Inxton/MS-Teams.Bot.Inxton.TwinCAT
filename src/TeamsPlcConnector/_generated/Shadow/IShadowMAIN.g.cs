using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace TeamsPlc
{
	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowMAIN : Vortex.Connector.IVortexShadowObject
	{
		IShadowTeamsApp App
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		TeamsPlc.PlainMAIN CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(TeamsPlc.PlainMAIN source);
	}
}