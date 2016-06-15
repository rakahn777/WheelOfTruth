using UnityEngine;
using System.Collections;

public class ResLogin
{
    public string key;
    public string user_id;
    public string device_id;
    public string device_os;
    public string device_token;
    public User user;
}

public class ResSpin
{
    public string first_round;
    public string second_round;
    public string third_round;
}

public class StartMachine
{
    public RewardInfo[] rewards;

    public StartMachine(RewardInfo[] r)
    {
        this.rewards = r;
    }
}

public class SpinWheelParameter
{
    public RoundType roundType;
    public RewardInfo reward;

    public SpinWheelParameter(RoundType type, RewardInfo reward)
    {
        this.roundType = type;
        this.reward = reward;
    }
}
