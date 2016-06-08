using UnityEngine;
using System.Collections;

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

    public SendStartWheel(string token)
    {
        this.token = token;
    }
}
