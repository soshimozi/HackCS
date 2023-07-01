using System.Drawing;

namespace HackCS.Hack.ComputerParts;

public interface IBusGUI : IComputerPartGUI
{
    void Move(Point? sourceCoordinates, Point? targetCoordinates, string? value);
    void SetSpeed(int speedUnit);
}