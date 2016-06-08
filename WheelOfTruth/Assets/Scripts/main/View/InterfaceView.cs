using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using nFury.Utils.Core;

public class InterfaceView : View
{
    public GameObject btnSpin1;

    private void Awake()
    {
        UIEventListener.Get(btnSpin1).onClick += Spin1;
    }

    private void Spin1(GameObject o)
    {
        Service.Get<SignalManager>().sendAPIStartWheelSignal.Dispatch();
    }
}
