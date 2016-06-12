using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class MachineControllerMediator : Mediator
{
    [Inject]
    public MachineControllerView view { get; set; }

	
}
