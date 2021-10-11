using System;

namespace _Plc_.TeamsPlc
{
#if PLC_DOCU
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
	public abstract class TeamsApp
	{
		
///		<summary>
///			Main method of the TcoContext. This is the entry point of any control logic that belongs to this context. 
///			The call of this method is ensured by calling the <c>InstanceName.Run()</c> method, and it must not be called explicitly.
///			This method is abstract, and it must be overridden in derived block.
///		</summary>
///<summary><note type="note">This is PLC method. This method is invokable only from the PLC code.</note></summary>
///<returns>Plc type VOID; Twin type: <see cref="void"/></returns>

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced), Vortex.Connector.IgnoreReflectionAttribute()]
		protected void Main()
		{
			throw new NotImplementedException("This is PLC member; not invokable form the PC side.");
		}

		public TcoCore.TcoTask StartTheMachine;
		public TcoCore.TcoTask StopTheMachine;
		public object IsMachineRunning;
		public object MessageFromPlc;
		///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
		public TeamsApp()
		{
		}
	}
#endif
}