using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace TeamsPlc
{
	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IMAIN : Vortex.Connector.IVortexOnlineObject
	{
		ITeamsApp App
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		TeamsPlc.PlainMAIN CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(TeamsPlc.PlainMAIN source);
		void FlushOnlineToPlain(TeamsPlc.PlainMAIN source);
	}
}