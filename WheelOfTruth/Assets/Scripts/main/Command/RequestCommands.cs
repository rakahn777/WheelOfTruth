using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using nFury.Utils.Core;

namespace cmds
{
    public class SendAPILoginEmailCmd : Command
    {
        [Inject]
        public SendLoginEmail send { get; set; }

        public override void Execute()
        {
            RequestManager.instance.APILoginEmail(send);
        }
    }

    public class SendAPIStartWheelCmd : Command
    {
        public override void Execute()
        {
            RequestManager.instance.APIStartWheel(Service.Get<UserData>().session.key);
        }
    }
}
