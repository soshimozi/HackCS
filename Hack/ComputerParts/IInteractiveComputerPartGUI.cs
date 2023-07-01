using System;
namespace HackCS.Hack.ComputerParts
{
	public interface IInteractiveComputerPartGUI : IComputerPartGUI
	{
        event EventHandler<ErrorEventArgs>? Error;
    }
}

