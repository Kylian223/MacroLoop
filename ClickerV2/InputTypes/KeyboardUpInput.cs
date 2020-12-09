using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClickerV2.InputTypes
{
    class KeyboardUpInput : IInput
    {
        InputSimulator simulator = new InputSimulator();
        public VirtualKeyCode Key { get; set; }
        public int PreInterval { get; set; }
        public int PostInterval { get; set; }

        public KeyboardUpInput(VirtualKeyCode key, int preinterval,int postinterval)
        {
            Key = key;
            PreInterval = preinterval;
            PostInterval = postinterval;
        }
        public void ExecuteInput()
        {
            Thread.Sleep(PreInterval);
            simulator.Keyboard.KeyUp(Key);
            Thread.Sleep(PostInterval);
        }
    }
}
