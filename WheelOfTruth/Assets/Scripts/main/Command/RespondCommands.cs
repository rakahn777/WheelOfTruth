using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using LitJson;
using nFury.Utils.Core;
using signals;

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
        [Inject]
        public StartMachineSignal startSignal { get; set; }

        public override void Execute()
        {
            ResSpin res = JsonMapper.ToObject<ResSpin>(content);

            Debug.Log(JsonMapper.ToJson(res));

            WheelConfig config = Service.Get<ConfigManager>().GetWheelConfig();

            RewardInfo r1 = res.first_round != null ? config.GetReward(res.first_round.ToLower()) : null;
            RewardInfo r2 = res.second_round != null ? config.GetReward(res.second_round.ToLower()) : null;
            RewardInfo r3 = res.third_round != null ? config.GetReward(res.third_round.ToLower()) : null;

            startSignal.Dispatch(new StartMachine(new RewardInfo[] { r1, r2, r3 }));
        }
    }
}
