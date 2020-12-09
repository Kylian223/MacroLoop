using GregsStack.InputSimulatorStandard.Native;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ClickerV2.InputTypes
{
    interface IInput
    {
        public int PreInterval { get; set; }
        public int PostInterval { get; set; }
        public void ExecuteInput();
    }
    public enum MouseInputs
    {
        LeftMouse,
        RightMouse,
        MiddleMouse
    }
}
