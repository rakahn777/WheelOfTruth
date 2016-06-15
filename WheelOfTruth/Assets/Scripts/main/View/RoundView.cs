using UnityEngine;
using System.Collections;
using nFury.Utils.Core;
using strange.extensions.mediation.impl;
using System.Collections.Generic;

public class RoundView : View 
{
    public RoundType type;
    public int numberOfSlots;
    public GameObject container;
    
    private WheelView wheel;
    private float slotAngle;
    private SlotView[] slotViews;

    #region Init
    internal void Init()
    {
        slotAngle = 360f / numberOfSlots;

        wheel = gameObject.GetComponent<WheelView>();
        wheel.finishSignal.AddListener(OnFinishSpin);

        GenerateSlots();
        InitData();
    }

    private void OnDestroy()
    {
        wheel.finishSignal.RemoveListener(OnFinishSpin);
    }

    private void GenerateSlots()
    {
        slotViews = new SlotView[numberOfSlots];

        GameObject prefab = Resources.Load<GameObject>(AssetsPath.SLOT_ROUND + GetRoundIndex());
        
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject _slot = NGUITools.AddChild(container, prefab);
            _slot.transform.Rotate(Vector3.forward, -slotAngle * i);
            slotViews[i] = _slot.GetComponent<SlotView>();
        }
    }

    private void InitData()
    {
        WheelConfig config = Service.Get<ConfigManager>().GetWheelConfig();
        RoundRewardInfo[] rewards = config.GetRound(type);
        int roundIndex = GetRoundIndex();

        for (int i = 0; i < numberOfSlots; i++)
        {
            RewardInfo _r = config.GetRewardById(rewards[i].id);
            slotViews[i].Show(_r, roundIndex);
        }
    }

    private int GetRoundIndex()
    {
        return ((int)type + 1);
    }

    #endregion

    public void SpinWheel(SpinWheelParameter param)
    {
        if (param.roundType != type || param.reward == null) return;

        int _index = 0;
        List<int> matchedSlots = new List<int>();
        for (int i = 0; i < slotViews.Length; i++)
        {
            if (slotViews[i].GetRewardId() == param.reward.id)
            {
                matchedSlots.Add(i);
                break;
            }
        }
        _index = matchedSlots[Random.Range(0, matchedSlots.Count)];
        wheel.StartSpin(_index);
    }

    private void OnFinishSpin()
    {
        Service.Get<SignalManager>().onSpinFinishSignal.Dispatch(type);
    }
}
