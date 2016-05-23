using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

public class RequestManager : MonoBehaviour 
{
    public string SERVER_URL = "http://23.251.156.209/public/v1/";

    //test
    private string token;

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

        StartCoroutine(WaitForRequest(www, null));
    }

    public void APILoginEmail()
    {
        string url = SERVER_URL + "users/auth";

        WWWForm form = new WWWForm();
        form.AddField("email", "123@gmail.com");
        form.AddField("password", "12345678");
        form.AddField("device_id", SystemInfo.deviceUniqueIdentifier);
        form.AddField("device_type", "Android");        
        WWW www = new WWW(url, form);
        
        Debug.Log(LitJson.JsonMapper.ToJson(form));
        
        StartCoroutine(WaitForRequest(www, null));
    }

    public void APILogout()
    {
        string url = SERVER_URL + "users/1/logout";

        WWWForm form = new WWWForm();
        form.AddField("token", token);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www, null));
    }

    public void APIGetUserInfo()
    {
        string url = SERVER_URL + "users/1/show?token=";
        url += token;
        WWW www = new WWW(url);

        StartCoroutine(WaitForRequest(www, null));
    }

    public void APIStartWheel()
    {
        string url = SERVER_URL + "wheels/start";

        WWWForm form = new WWWForm();
        form.AddField("token", token);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www, null));
    }

    private IEnumerator WaitForRequest(WWW www, Signal<string> signal)
    {
        yield return www;

        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            ResLogin res = LitJson.JsonMapper.ToObject<ResLogin>(www.text);
            Debug.Log(res.key);
            token = res.key;

            //signal.Dispatch(www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
