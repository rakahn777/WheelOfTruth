using UnityEngine;
using System.Collections;
using nFury.Utils.Core;
using signals;

public class SignalManager
{

    #region API Request

    [Inject]
    public SendAPILoginEmailSignal sendAPILoginEmailSignal { get; set; }
    [Inject]
    public SendAPIStartWheelSignal sendAPIStartWheelSignal { get; set; }

    #endregion

    #region API Respond

    [Inject]
    public OnAPIRegisterNewUserSignal onAPIRegisterNewUserSignal { get; set; }
    [Inject]
    public OnAPILoginEmailSignal onAPILoginEmailSignal { get; set; }
    [Inject]
    public OnAPILogoutSignal onAPILogoutSignal { get; set; }
    [Inject]
    public OnAPIGetUserInfoSignal onAPIGetUserInfoSignal { get; set; }
    [Inject]
    public OnAPIStartWheelSignal onAPIStartWheelSignal { get; set; }

    #endregion

    #region UI

    [Inject]
    public SpinWheelSignal spinWheelSignal { get; set; }
    [Inject]
    public OnSpinFinishSignal onSpinFinishSignal { get; set; }

    #endregion

    public void Initialization()
    {
        Service.Set(this);
    }
}
