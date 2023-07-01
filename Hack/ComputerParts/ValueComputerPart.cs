namespace HackCS.Hack.ComputerParts;

public abstract class ValueComputerPart : ComputerPart
{
    private static readonly int FLASH_TIME = 500;

    protected short nullValue;

    private object synchronize = new object();

    public ValueComputerPart(bool hasGUI) : base(hasGUI)
    {}

    public void SetValueAt(int index, short value, bool quiet)
    {
        DoSetValueAt(index, value);

    }

    public abstract void DoSetValueAt(int index, short value);

    public abstract short GetValueAt(int index);

    public void UpdateGUI(int index, short value)
    {
        lock (synchronize)
        {
            if (!DisplayChanges) return;
            var gui =  GetGUI() as IValueComputerPartGUI;
            gui?.SetValueAt(index, value);

            if (Animate)
            {
                gui?.Flash(index);
                Thread.Sleep(FLASH_TIME);

                gui?.HideFlash();
            }

            gui?.Highlight(index);
        }
    }

    public void QuietUpdateGUI(int index, short value)
    {
        if (!DisplayChanges) return;

        (GetGUI() as IValueComputerPartGUI)?.SetValueAt(index, value);
    }

    public void HideHighlight()
    {
        if (!DisplayChanges) return;

        (GetGUI() as IValueComputerPartGUI)?.HideHighlight();
    }

    public void SetNumericFormat(int formatCode)
    {
        if(!DisplayChanges) return;

        (GetGUI() as IValueComputerPartGUI)?.SetNumericFormat(formatCode);
    }

    public void SetNullValue(short value, bool hideNullValue)
    {
        nullValue = value;

        if(!HasGui) return;

        (GetGUI() as IValueComputerPartGUI)?.SetNullValue(value, hideNullValue);
    }


}