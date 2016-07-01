using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using nFury.Utils.Core;

public class InterfaceView : View
{
    public GameObject btnSpin1;
    public GameObject btnSpin2;
    public GameObject btnSpin3;

    private void Awake()
    {
        UIEventListener.Get(btnSpin1).onClick += Spin1;
        UIEventListener.Get(btnSpin2).onClick += Spin2;
        UIEventListener.Get(btnSpin3).onClick += Spin3;
    }

    private void Spin1(GameObject o)
    {
        Service.Get<SignalManager>().sendAPIStartWheelSignal.Dispatch(new SendStartWheel(0));
    }

    private void Spin2(GameObject o)
    {
        Service.Get<SignalManager>().sendAPIStartWheelSignal.Dispatch(new SendStartWheel(1));
    }
    private void Spin3(GameObject o)
    {
        Service.Get<SignalManager>().sendAPIStartWheelSignal.Dispatch(new SendStartWheel(2));
    }
}
