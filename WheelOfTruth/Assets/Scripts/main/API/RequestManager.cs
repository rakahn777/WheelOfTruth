using UnityEngine;
using System.Collections;

public class RequestManager : MonoBehaviour 
{
    public void APIRegisterNewUser()
    {
        string url = "http://23.251.156.209/public/v1/users";

        WWWForm form = new WWWForm();
        form.AddField("email", "123@gmail.com");
        form.AddField("password", "12345678");
        form.AddField("password_confirmation", "12345678");
        form.AddField("name", "Testchoi");
        form.AddField("phone_number", "0123456789");
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www, null));
    }

    private IEnumerator WaitForRequest(WWW www, EventDelegate callback)
    {
        yield return www;

        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
