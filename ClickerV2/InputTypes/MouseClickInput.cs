using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClickerV2.InputTypes
{
    class MouseClickInput : IInput
    {
        InputSimulator simulator = new InputSimulator();
        public MouseInputs Key { get; set; }
        public int PreInterval { get; set; }
        public int PostInterval { get; set; }

        public MouseClickInput(MouseInputs key, int preinterval,int postinterval)
        {
            Key = key;
            PreInterval = preinterval;
            PostInterval = postinterval;
        }
        public void ExecuteInput()
        {
            if (Key == MouseInputs.LeftMouse)
            {
                Thread.Sleep(PreInterval);
                simulator.Mouse.LeftButtonClick();
                Thread.Sleep(PostInterval);
            }
            else if (Key == MouseInputs.RightMouse)
            {
                Thread.Sleep(PreInterval);
                simulator.Mouse.RightButtonClick();
                Thread.Sleep(PostInterval);
            } 
            else if (Key == MouseInputs.MiddleMouse)
            {
                Thread.Sleep(PreInterval);
                simulator.Mouse.MiddleButtonClick();
                Thread.Sleep(PostInterval);
                Thread.Sleep(PostInterval);
            }
        }
    }
}
