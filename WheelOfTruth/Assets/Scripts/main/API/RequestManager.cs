using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;
using nFury.Utils.Core;

public class RequestManager : MonoSingleton<RequestManager>
{
    public string SERVER_URL = "http://23.251.156.209/public/v1/";

    public void APIRegisterNewUser()
    {
        string url = SERVER_URL + "users";

        WWWForm form = new WWWForm();
        form.AddField("email", "123@gmail.com");
        form.AddField("password", "12345678");
        form.AddField("password_confirmation", "12345678");
        form.AddField("name", "Testchoi");
        form.AddField("phone_number", "0123456789");
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www, Service.Get<SignalManager>().onAPIRegisterNewUserSignal));
    }

    public void APILoginEmail(SendLoginEmail send)
    {
        string url = SERVER_URL + "users/auth";

        WWWForm form = new WWWForm();
        form.AddField("email", "123@gmail.com");
        form.AddField("password", "12345678");
        form.AddField("device_id", SystemInfo.deviceUniqueIdentifier);
        form.AddField("device_type", "Android");        
        WWW www = new WWW(url, form);
        
        Debug.Log(LitJson.JsonMapper.ToJson(form));
        
        StartCoroutine(WaitForRequest(www, Service.Get<SignalManager>().onAPILoginEmailSignal));
    }

    public void APILogout(string token)
    {
        string url = SERVER_URL + "users/1/logout";

        WWWForm form = new WWWForm();
        form.AddField("token", token);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www, Service.Get<SignalManager>().onAPILogoutSignal));
    }

    public void APIGetUserInfo(string userID, string token)
    {
        string url = string.Format(SERVER_URL + "users/{0}/show?token={1}", userID, token);
        WWW www = new WWW(url);

        StartCoroutine(WaitForRequest(www, Service.Get<SignalManager>().onAPIGetUserInfoSignal));
    }

    public void APIStartWheel(string token)
    {
        string url = SERVER_URL + "wheels/start";

        WWWForm form = new WWWForm();
        form.AddField("token", token);
        //form.AddField("test", 2);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www, Service.Get<SignalManager>().onAPIStartWheelSignal));
    }

    private IEnumerator WaitForRequest(WWW www, Signal<string> signal)
    {
        yield return www;

        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);

            if (signal != null) signal.Dispatch(www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
