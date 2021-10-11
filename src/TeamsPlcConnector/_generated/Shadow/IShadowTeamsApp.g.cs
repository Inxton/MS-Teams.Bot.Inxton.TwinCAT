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
	public partial interface IShadowTeamsApp : Vortex.Connector.IVortexShadowObject
	{
		TcoCore.IShadowTcoTask StartTheMachine
		{
			get;
		}

		TcoCore.IShadowTcoTask StopTheMachine
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowBool IsMachineRunning
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowString MessageFromPlc
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		TeamsPlc.PlainTeamsApp CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(TeamsPlc.PlainTeamsApp source);
	}
}