using UnityEngine;
using System.Collections;
using nFury.Utils.Core;

public class SendLoginEmail
{
    public string email;
    public string password;
    public string device_id;
    public string device_type;

    public SendLoginEmail(string email, string password, string device_id, string device_type)
    {
        this.email = email;
        this.password = password;
        this.device_id = device_id;
        this.device_type = device_type;
    }
}

public class SendStartWheel
{
    public string token;
    public int from;
    
    public SendStartWheel(int startFrom)
    {
        this.token = Service.Get<UserData>().session.key;
        this.from = startFrom;
    }

    public SendStartWheel(string token, int startFrom)
    {
        this.token = token;
        this.from = startFrom;
    }
}
