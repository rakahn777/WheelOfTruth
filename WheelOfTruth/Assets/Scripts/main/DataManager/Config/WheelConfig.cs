using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WheelConfig
{
    public Dictionary<string, RewardInfo> results = new Dictionary<string, RewardInfo>();
    public Dictionary<string, RoundRewardInfo> round = new Dictionary<string, RoundRewardInfo>();
    
    public RewardInfo GetReward(string key)
    {
        return results[key];
    }

    public RoundRewardInfo[] GetRound(RoundType type)
    {
        List<RoundRewardInfo> _r = new List<RoundRewardInfo>();
        foreach (RoundRewardInfo value in round.Values)
        {
            if (value.round == type)
                _r.Add(value);
        }

        return _r.ToArray();
    }
}

public enum RoundType
{
    FIRST   = 0,
    SECOND  = 1,
    THIRD   = 2
}

public enum RewardType
{
    STAR        = 0,
    EXP         = 1,
    MINI_GAME   = 2,
    UP          = 3,
    MORE_TURN   = 4,
    DEAD_SLOT   = 5,
    GIFT        = 6,
    JACKPOT     = 7
}

public class RewardInfo
{
    public int id { get; set; }
    public RewardType type { get; set; }
    public int star { get; set; }
    public int exp { get; set; }
    public int turn { get; set; }
}

public class RoundRewardInfo
{
    public int id { get; set; }
    public RoundType round { get; set; }
}
