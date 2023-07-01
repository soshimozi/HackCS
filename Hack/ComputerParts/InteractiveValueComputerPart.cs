using System;
using System.Numerics;
using HackCS.Hack.Events;
using ErrorEventArgs = HackCS.Hack.Events.ErrorEventArgs;

namespace HackCS.Hack.ComputerParts;

public abstract class InteractiveValueComputerPart : ValueComputerPart
{
    public event EventHandler<ErrorEventArgs>? Error;

    // The excepted range of numbers
    private short _minValue, _maxValue;

    // The current enabled range
    private int _startEnabledRange, _endEnabledRange;

    // If true, disabled range will be gray
    private bool _grayDisabledRange;

    public InteractiveValueComputerPart(bool hasGUI) : base(hasGUI)
	{

        _minValue = -32768;
        _maxValue = 32767;

        _startEnabledRange = -1;
        _endEnabledRange = -1;
    }

    public InteractiveValueComputerPart(bool hasGUI, short minValue, short maxValue) : base(hasGUI)
    {

        _minValue = minValue;
        _maxValue = maxValue;
    }

    public void ErrorOccured(string message)
    {
        OnError(this, message);
    }

    public void guiGainedFocus()
    {
    }

    /**
     * Enables user input into the computer part.
     */
    public void EnableUserInput()
    {
        if (HasGui)
            (GetGUI() as IInteractiveValueComputerPartGUI).enableUserInput();
    }

    /**
     * Disables user input into the computer part.
     */
    public void disableUserInput()
    {
        if (hasGUI)
            ((InteractiveValueComputerPartGUI)getGUI()).disableUserInput();
    }


    protected void OnError(object sender, string message)
    {
        Error?.Invoke(sender, new ErrorEventArgs(message));
    }
}

