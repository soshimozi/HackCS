using System;
namespace HackCS.Hack.Events
{
	public class ComputerPartErrorEventArgs : EventArgs
	{
		public string Message { get; set; }

		public ComputerPartErrorEventArgs(string message)
		{
			Message = message;
		}
	}
}

