using System;
using HackCS.Hack.ComputerParts;

namespace HackCS.Hack.Events
{
	public class ComputerPartEventArgs : EventArgs
    {
        public int Index { get; }
        public short Value { get; }

        public ComputerPartEventArgs(int index, short value)
        {
           Index = index;
            Value = value;
        }

	}
}

