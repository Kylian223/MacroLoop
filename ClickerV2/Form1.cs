using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GregsStack.InputSimulatorStandard.Native;
using GregsStack.InputSimulatorStandard;
using System.Drawing.Imaging;
using ClickerV2.InputTypes;
using ClickerV2.BehaviourTypes;
using System.Diagnostics;

namespace ClickerV2
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        InputSimulator simulator = new InputSimulator();
        BehaviourContainer bc = new BehaviourContainer();

        //linker muisknop up en down waardes
        private const int LEFTDOWN = 0x0002;
        private const int LEFTUP = 0x0004;
        private const int RIGHTDOWN = 0x0008;
        private const int RIGHTUP = 0x0010;

        //interval in milliseconds
        public int interval = 50;
        public bool enabled = false;
        private int behaviourstate = 0;

        //Background workers (BW) Threads that work in the background

        //BackgroundWorker for detecting user input intended for the application
        static BackgroundWorker BW_InputHandler = new BackgroundWorker { WorkerSupportsCancellation = true, WorkerReportsProgress= true };
        //BackgroundWorker that runs Behaviours
        static BackgroundWorker BW_BehaviourHandler = new BackgroundWorker { WorkerSupportsCancellation = true, WorkerReportsProgress= true };
        //BackgroundWorker that choses Behaviours (gets information from game to decide)
        static BackgroundWorker BW_BehaviourPicker = new BackgroundWorker { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            BW_InputHandler.DoWork += BW_InputHandler_DoWork;
            BW_BehaviourHandler.DoWork += BW_BehaviourHandler_DoWork;
            BW_BehaviourPicker.DoWork += BW_BehaviourPicker_DoWork;
            BW_InputHandler.RunWorkerAsync();
            BW_BehaviourHandler.RunWorkerAsync();
            BW_BehaviourPicker.RunWorkerAsync();
        }
        private void BW_BehaviourHandler_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                if (enabled == true)
                {
                    switch (behaviourstate) {
                        case 1:
                            bc.MoveForwardAndShoot.StartBehaviour();
                            break;
                        case 2:
                            bc.StopMoving.StartBehaviour();
                            behaviourstate = 0;
                            break;
                        case 3:
                            bc.BackUpAndHeal.StartBehaviour();
                            behaviourstate = 1;
                            break;
                        case 4:
                            bc.BackUpAndUseMantle.StartBehaviour();
                            behaviourstate = 1;
                            break;
                        case 5:
                            bc.SwitchAmmo1.StartBehaviour();
                            behaviourstate = 7;
                            break;
                        case 6:
                            bc.SwitchAmmo2.StartBehaviour();
                            behaviourstate = 1;
                            break;
                        case 7:
                            bc.Shoot3TimesThenDodgeReload.StartBehaviour();
                            break;
                        case 9:
                            bc.Shiken.StartBehaviour();
                            break;
                    }
                }
                Thread.Sleep(2);
            }
        }
        private void BW_BehaviourPicker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                if (enabled == true)
                {
                    //Stopwatch timer = new Stopwatch();
                    //timer.Start();
                    //behaviourstate = 4;
                    //Thread.Sleep(50);
                    //behaviourstate = 1;
                    //Thread.Sleep(3400);
                    //while (timer.ElapsedMilliseconds < 180000)
                    //{
                    //    behaviourstate = 5;
                    //    Thread.Sleep(50);
                    //    behaviourstate = 1;
                    //    Thread.Sleep(10000);
                    //    behaviourstate = 6;
                    //    Thread.Sleep(50);
                    //    behaviourstate = 1;
                    //    Thread.Sleep(10000);
                    //}


                    if (GetAsyncKeyState(Keys.NumPad1) < 0)
                    {
                        behaviourstate = 1;
                    }
                    else if (GetAsyncKeyState(Keys.NumPad2) < 0)
                    {
                        behaviourstate = 2;
                    }
                    else if (GetAsyncKeyState(Keys.NumPad3) < 0)
                    {
                        behaviourstate = 3;
                    }
                    else if (GetAsyncKeyState(Keys.NumPad4) < 0)
                    {
                        behaviourstate = 4;
                    }
                    else if (GetAsyncKeyState(Keys.NumPad5) < 0)
                    {
                        behaviourstate = 5;
                    }
                    else if (GetAsyncKeyState(Keys.NumPad6) < 0)
                    {
                        behaviourstate = 6;
                    }
                    else if (GetAsyncKeyState(Keys.NumPad0) < 0)
                    {
                        behaviourstate = 0;
                    }
                    else if (GetAsyncKeyState(Keys.NumPad9) < 0)
                    {
                        behaviourstate = 9;
                    }
                }
            }
        }

        private void BW_InputHandler_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                if (GetAsyncKeyState(Keys.Oemplus) < 0)
                {
                    enabled = true;
                    label3.Text = "Status: ON";
                    label3.ForeColor = Color.FromArgb(0, 192, 0);
                }
                else if (GetAsyncKeyState(Keys.OemMinus) < 0)
                {
                    enabled = false;
                    label3.Text = "Status: OFF";
                    label3.ForeColor = Color.FromArgb(192, 0, 0);
                }
                if(1 == 0)
                {
                    // ##code examples##

                    // Hold down W key
                    simulator.Keyboard.KeyDown(VirtualKeyCode.VK_W);
                    // Release W key
                    simulator.Keyboard.KeyUp(VirtualKeyCode.VK_W);
                    // Press W key once
                    simulator.Keyboard.KeyPress(VirtualKeyCode.VK_W);

                    // Move mouse by x,y coordinates relative to current position
                    simulator.Mouse.MoveMouseBy(1, 1);
                    // Click left mouse button once
                    simulator.Mouse.LeftButtonClick();
                    // Hold down left mouse button 
                    simulator.Mouse.LeftButtonDown();
                    // Release left mouse button
                    simulator.Mouse.LeftButtonUp();

                }
                Thread.Sleep(10);
            }
        }

    }
}
