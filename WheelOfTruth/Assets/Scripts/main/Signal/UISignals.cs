using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

namespace signals
{
    public class StartMachineSignal : Signal<StartMachine> { }
    public class SpinWheelSignal : Signal<SpinWheelParameter> { }
    public class OnSpinFinishSignal : Signal<RoundType> { }
}
