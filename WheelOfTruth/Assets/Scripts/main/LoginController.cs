using UnityEngine;
using System.Collections;
using nFury.Utils.Core;

public class LoginController : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
        Debug.Log(Service.Get<SignalManager>().sendAPILoginEmailSignal);
        Service.Get<SignalManager>().sendAPILoginEmailSignal.Dispatch(new SendLoginEmail(
            "123@gmail.com",
            "12345678",
            SystemInfo.deviceUniqueIdentifier,
            "Android"));
	}
}
