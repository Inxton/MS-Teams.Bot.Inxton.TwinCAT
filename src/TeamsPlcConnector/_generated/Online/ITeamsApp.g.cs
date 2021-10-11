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
	public partial interface ITeamsApp : Vortex.Connector.IVortexOnlineObject
	{
		TcoCore.ITcoTask StartTheMachine
		{
			get;
		}

		TcoCore.ITcoTask StopTheMachine
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineBool IsMachineRunning
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineString MessageFromPlc
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		TeamsPlc.PlainTeamsApp CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(TeamsPlc.PlainTeamsApp source);
		void FlushOnlineToPlain(TeamsPlc.PlainTeamsApp source);
	}
}