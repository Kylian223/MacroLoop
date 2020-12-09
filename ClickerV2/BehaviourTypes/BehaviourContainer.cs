using ClickerV2.InputTypes;
using System;
using System.Collections.Generic;
using System.Text;
using GregsStack.InputSimulatorStandard.Native;

namespace ClickerV2.BehaviourTypes
{
    class BehaviourContainer
    {
        public Behaviour MoveForwardAndShoot = new Behaviour(new List<IInput>
        {
            new KeyboardDownInput(VirtualKeyCode.VK_W,0,5),
            new MouseDownInput(MouseInputs.LeftMouse,0,200),
            new MouseUpInput(MouseInputs.LeftMouse,0,200),
        });
        public Behaviour Shoot3TimesThenDodgeReload = new Behaviour(new List<IInput>
        {
            new KeyboardUpInput(VirtualKeyCode.VK_W,0,50),
            new KeyboardDownInput(VirtualKeyCode.VK_W,0,500),
            new KeyboardUpInput(VirtualKeyCode.VK_W,0,50),

            new MouseDownInput(MouseInputs.LeftMouse,0,200),
            new MouseUpInput(MouseInputs.LeftMouse,0,1500),
            new MouseDownInput(MouseInputs.LeftMouse,0,200),
            new MouseUpInput(MouseInputs.LeftMouse,0,1500),
            new MouseDownInput(MouseInputs.LeftMouse,0,200),
            new MouseUpInput(MouseInputs.LeftMouse,0,1000),

            new KeyboardDownInput(VirtualKeyCode.VK_A,0,50),

            new KeyboardDownInput(VirtualKeyCode.SPACE,0,50),
            new KeyboardUpInput(VirtualKeyCode.SPACE,0,700),
            new KeyboardDownInput(VirtualKeyCode.SPACE,0,50),
            new KeyboardUpInput(VirtualKeyCode.SPACE,0,50),

            new KeyboardUpInput(VirtualKeyCode.VK_A,0,1000),
        });

        public Behaviour StopMoving = new Behaviour(new List<IInput>
        {
            new KeyboardUpInput(VirtualKeyCode.VK_W,0,5)
        });
        public Behaviour SwitchAmmo1 = new Behaviour(new List<IInput>
        {
            new KeyboardDownInput(VirtualKeyCode.F2,0,50),
            new KeyboardUpInput(VirtualKeyCode.F2,0,200),

            new KeyboardDownInput(VirtualKeyCode.VK_3,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_3,0,200),

            new KeyboardDownInput(VirtualKeyCode.F1,0,50),
            new KeyboardUpInput(VirtualKeyCode.F1,0,200),
        });
        public Behaviour SwitchAmmo2 = new Behaviour(new List<IInput>
        {
            new KeyboardDownInput(VirtualKeyCode.F2,0,50),
            new KeyboardUpInput(VirtualKeyCode.F2,0,200),

            new KeyboardDownInput(VirtualKeyCode.VK_4,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_4,0,200),

            new KeyboardDownInput(VirtualKeyCode.F1,0,50),
            new KeyboardUpInput(VirtualKeyCode.F1,0,200),
        });
        public Behaviour BackUpAndHeal = new Behaviour(new List<IInput>
        {
            new KeyboardUpInput(VirtualKeyCode.VK_W,0,50),
            new KeyboardDownInput(VirtualKeyCode.VK_S,0,30),
            new KeyboardDownInput(VirtualKeyCode.VK_A,0,50),

            new KeyboardDownInput(VirtualKeyCode.SPACE,0,50),
            new KeyboardUpInput(VirtualKeyCode.SPACE,0,700),
            new KeyboardDownInput(VirtualKeyCode.SPACE,0,50),
            new KeyboardUpInput(VirtualKeyCode.SPACE,0,600),

            new KeyboardDownInput(VirtualKeyCode.SHIFT,0,50),

            new KeyboardDownInput(VirtualKeyCode.VK_1,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_1,0,1000),
            new KeyboardDownInput(VirtualKeyCode.VK_1,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_1,0,500),
            new KeyboardDownInput(VirtualKeyCode.VK_1,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_1,0,50),

            new KeyboardUpInput(VirtualKeyCode.VK_S,0,3500),
            new KeyboardUpInput(VirtualKeyCode.VK_A,0,50),
            new KeyboardUpInput(VirtualKeyCode.SHIFT,0,50),
            
        });
        public Behaviour BackUpAndUseMantle = new Behaviour(new List<IInput>
        {
            new KeyboardUpInput(VirtualKeyCode.VK_W,0,50),
            new KeyboardDownInput(VirtualKeyCode.VK_S,0,50),
            new KeyboardDownInput(VirtualKeyCode.VK_A,0,50),
            new KeyboardDownInput(VirtualKeyCode.SHIFT,0,50),

            new KeyboardDownInput(VirtualKeyCode.VK_5,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_5,0,1200),
            new KeyboardDownInput(VirtualKeyCode.VK_5,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_5,0,500),
            new KeyboardDownInput(VirtualKeyCode.VK_5,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_5,0,1300),

            new KeyboardUpInput(VirtualKeyCode.VK_S,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_A,0,50),
            new KeyboardUpInput(VirtualKeyCode.SHIFT,0,50),
        });
        public Behaviour Shiken = new Behaviour(new List<IInput>
        {
            new KeyboardDownInput(VirtualKeyCode.VK_W,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_W,0,300),

            new KeyboardDownInput(VirtualKeyCode.VK_A,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_A,0,300),

            new KeyboardDownInput(VirtualKeyCode.VK_D,0,50),
            new KeyboardUpInput(VirtualKeyCode.VK_D,0,500),
        });

    }
    public enum BehaviourInstance
    {

    }
}
