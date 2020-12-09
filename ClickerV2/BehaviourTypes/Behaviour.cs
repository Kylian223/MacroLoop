using System;
using System.Collections.Generic;
using System.Text;
using ClickerV2.InputTypes;

namespace ClickerV2.BehaviourTypes
{
    class Behaviour
    {
        public List<IInput> inputs { get; set; }
        public Behaviour(List<IInput> list)
        {
            inputs = list;
        }
        public void StartBehaviour()
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                inputs[i].ExecuteInput();
            }
        }
    }
}