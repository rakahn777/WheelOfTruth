using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using signals;

public class RoundMediator : Mediator
{
    [Inject]
    public RoundView view { get; set; }
    [Inject]
    public SpinWheelSignal spinSignal { get; set; }

    public override void OnRegister()
    {
        view.Init();

        spinSignal.AddListener(Spin);
    }

    public override void OnRemove()
    {
        spinSignal.RemoveListener(Spin);
        
    }

    private void OnDestroy()
    {
        OnRemove();
    }

    private void Spin(SpinWheelParameter param)
    {
        view.SpinWheel(param);
    }
}
