namespace HackCS;

public class Bus : ComputerPart
{
    private readonly IBusGUI? _gui;

    public Bus(IBusGUI? gui) : base(gui != null)
    {
        _gui = gui;
    }

    public override IComputerPartGUI? GetGUI()
    {
        return _gui;
    }

    public override void RefreshGUI()
    {
    }

    public void SetAnimationSpeed(int speed)
    {
        if (!HasGui) return;
        _gui?.SetSpeed(speed);
    }

    public void Send(ValueComputerPart sourcePart, int sourceIndex, ValueComputerPart targetPart, int targetIndex)
    {
        if (Animate && sourcePart.GetAnimate() && HasGui)
        {
            Thread.Sleep(100);


            _gui?.Move((sourcePart.GetGUI() as IValueComputerPartGUI)?.GetCoordinates(sourceIndex),
                (targetPart.GetGUI() as IValueComputerPartGUI)?.GetCoordinates(targetIndex),
                (sourcePart.GetGUI() as IValueComputerPartGUI)?.GetValueAsString(sourceIndex));
        }

        targetPart.SetValueAt(targetIndex, sourcePart.GetValueAt(sourceIndex), false);
    }
}