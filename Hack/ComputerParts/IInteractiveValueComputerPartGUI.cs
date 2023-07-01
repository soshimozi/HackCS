using System;
namespace HackCS.Hack.ComputerParts
{
	public interface IInteractiveValueComputerPartGUI : IValueComputerPartGUI, IInteractiveComputerPartGUI
	{
		public event EventHandler ComputerPartEvent;
	}
}

