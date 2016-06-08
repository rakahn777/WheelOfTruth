using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

namespace signals
{
    public class SendAPIRegisterNewUserSignal : Signal { }
    public class SendAPILoginEmailSignal : Signal<SendLoginEmail> { }
    public class SendAPILogoutSignal : Signal { }
    public class SendAPIGetUserInfoSignal : Signal { }
    public class SendAPIStartWheelSignal : Signal { }
}
