using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCS;

public interface IValueComputerPartGUI : IComputerPartGUI
{
    Point GetCoordinates(int index);

    void SetValueAt(int index, short value);
    string GetValueAsString(int index);
    void Highlight(int index);
    void HideHighlight();
    void Flash(int index);
    void HideFlash();
    void SetNumericFormat(int formatCode);
    void SetNullValue(short value, bool hideNullValue);
}