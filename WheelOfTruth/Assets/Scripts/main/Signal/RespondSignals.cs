using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

namespace signals
{
    public class OnAPIRegisterNewUserSignal : Signal<string> { }
    public class OnAPILoginEmailSignal : Signal<string> { }
    public class OnAPILogoutSignal : Signal<string> { }
    public class OnAPIGetUserInfoSignal : Signal<string> { }
    public class OnAPIStartWheelSignal : Signal<string> { }
}
