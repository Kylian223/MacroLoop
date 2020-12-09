using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClickerV2.InputTypes
{
    class MouseUpInput : IInput
    {
        InputSimulator simulator = new InputSimulator();
        public MouseInputs Key { get; set; }
        public int PreInterval { get; set; }
        public int PostInterval { get; set; }

        public MouseUpInput(MouseInputs key, int preinterval,int postinterval)
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
                simulator.Mouse.LeftButtonUp();
                Thread.Sleep(PostInterval);
            }
            else if (Key == MouseInputs.RightMouse)
            {
                Thread.Sleep(PreInterval);
                simulator.Mouse.RightButtonUp();
                Thread.Sleep(PostInterval);
            } 
            else if (Key == MouseInputs.MiddleMouse)
            {
                Thread.Sleep(PreInterval);
                simulator.Mouse.MiddleButtonUp();
                Thread.Sleep(PostInterval);
            }
        }
    }
}
