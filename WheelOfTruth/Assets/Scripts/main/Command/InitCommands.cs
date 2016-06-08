using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

namespace cmds
{
    public class InitDataManagerCmd : Command
    {
        [Inject]
        public SignalManager signalManager { get; set; }

        public override void Execute()
        {
            signalManager.Initialization();

            new UserData();

            Debug.Log("Inited Data Manager");
        }
    }
}