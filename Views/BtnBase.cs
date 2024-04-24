using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views;

public abstract class BtnBase
{
    public PointF? Location { get; set; }

    public virtual void DrawButton (Graphics g) { }
}