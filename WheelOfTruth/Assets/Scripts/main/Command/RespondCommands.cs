using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using LitJson;
using nFury.Utils.Core;

namespace cmds
{
    public class BaseOnAPISuccessCmd : Command
    {
        [Inject]
        public string content { get; set; }
    }

    public class OnAPIRegisterNewUserCmd : BaseOnAPISuccessCmd
    {

    }

    public class OnAPILoginEmailCmd : BaseOnAPISuccessCmd
    {
        public override void Execute()
        {
            ResLogin res = JsonMapper.ToObject<ResLogin>(content);

            Session ses = new Session(
                res.key, 
                res.user_id, 
                res.device_id, 
                res.device_os, 
                res.device_token);
            Service.Get<UserData>().SetData(ses, res.user);

            Debug.Log(JsonMapper.ToJson(Service.Get<UserData>()));

            Application.LoadLevel("Game");
        }
    }

    public class OnAPILogoutCmd : BaseOnAPISuccessCmd
    {

    }

    public class OnAPIGetUserInfoCmd : BaseOnAPISuccessCmd
    {

    }

    public class OnAPIStartWheelCmd : BaseOnAPISuccessCmd
    {
        public override void Execute()
        {
            ResSpin res = JsonMapper.ToObject<ResSpin>(content);

            Debug.Log(JsonMapper.ToJson(res));

            RewardInfo r = Service.Get<ConfigManager>().GetWheelConfig().GetReward(res.first_round.ToLower());
            Debug.Log(JsonMapper.ToJson(r));

        }
    }
}
