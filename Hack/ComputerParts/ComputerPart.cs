namespace HackCS.Hack.ComputerParts;

public abstract class ComputerPart
{
    // If ture, changes to the computer part's values will be displayed in its gui
    protected bool DisplayChanges = true;

    // If true, changes to the computer part's values will be animated
    protected bool Animate;

    // when true, the ComputerPart should display its contents
    protected bool HasGui;

    public ComputerPart(bool hasGUI)
    {
        HasGui = hasGUI;
        DisplayChanges = hasGUI;
        Animate = false;
    }

    

    /// <summary>
    ///
    /// Sets the display changes property of the computer part.If set to true, changes
    /// that are made to the values of the computer part will be displayed in its GUI.
    /// Otherwise, changes will not be displayed.
    /// 
    /// </summary>
    /// <param name="trueOrFalse"></param>
    public void SetDisplayChanges(bool trueOrFalse)
    {
        DisplayChanges = trueOrFalse && HasGui;
    }

    public void SetAnimate(bool trueOrFalse)
    {
        Animate = trueOrFalse && HasGui;
    }

    public bool GetAnimate()
    { return Animate; }

    public void Reset()
    {
        if(HasGui)
            GetGUI()?.Reset();
    }

    public abstract IComputerPartGUI? GetGUI();
    public abstract void RefreshGUI();
}