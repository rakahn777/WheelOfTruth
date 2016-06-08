using UnityEngine;
using System.Collections;

public class UserData
{
    public Session session { get; set; }
    public User user { get; set; }

    public UserData()
    {
        nFury.Utils.Core.Service.Set(this);
    }

    public void SetData(Session session, User user)
    {
        this.session = session;
        this.user = user;
    }
}

public class Session
{
    public string key { get; set; }
    public string user_id { get; set; }
    public string device_id { get; set; }
    public string device_os { get; set; }
    public string device_token { get; set; }

    public Session()
    {

    }
    public Session(string key, string user_id, string device_id, string device_os, string device_token)
    {
        this.key = key;
        this.user_id = user_id;
        this.device_id = device_id;
        this.device_os = device_os;
        this.device_token = device_token;
    }
}

public class User
{
    public string email { get; set; }
    public string name { get; set; }
    public string facebook_id { get; set; }
    public string phone_number { get; set; }
    public string stars_number { get; set; }
    public string number_of_free_roll { get; set; }
    public string level_id { get; set; }
    public LevelObject level_object { get; set; }
}

public class LevelObject
{
    public string level { get; set; }
    public string current_exp { get; set; }
    public string max_exp_to_next_level { get; set; }
}
