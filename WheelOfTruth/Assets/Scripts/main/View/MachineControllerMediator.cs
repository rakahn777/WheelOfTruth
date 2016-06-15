using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using signals;

public class MachineControllerMediator : Mediator
{
    [Inject]
    public MachineControllerView view { get; set; }
    [Inject]
    public StartMachineSignal startSignal { get; set; }
    [Inject]
    public OnSpinFinishSignal onSpinFinishSignal { get; set; }

    public override void OnRegister()
    {
        startSignal.AddListener(view.RunMachine);
        onSpinFinishSignal.AddListener(view.OnSpinFinish);
    }

    public override void OnRemove()
    {
        startSignal.RemoveListener(view.RunMachine);     
        onSpinFinishSignal.RemoveListener(view.OnSpinFinish);
    }

    private void OnDestroy()
    {
        OnRemove();
    }
}
