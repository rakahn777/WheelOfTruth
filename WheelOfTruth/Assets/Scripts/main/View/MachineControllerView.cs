using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using nFury.Utils.Core;

public class MachineControllerView : View
{
    //Test
    public GameObject objBlock;
    public UILabel starLb;
    private int stars = 10000;

    private RewardInfo[] results;
    private int roundIndex;

    private void Start()
    {
        starLb.text = stars + "icon_star";
        NGUITools.SetActive(objBlock, false);
    }

    public void RunMachine(StartMachine param)
    {
        this.results = param.rewards;

        for (int i = 0; i < results.Length; i++ )
        {
            if (results[i] != null)
            {
                NGUITools.SetActive(objBlock, true);

                stars -= 1000;
                starLb.text = stars + "icon_star";

                roundIndex = i;
                SpinWheel();
                break;
            }
        }
    }

    public void OnSpinFinish(RoundType roundType)
    {
        if (roundIndex == (int)roundType)
        {
            stars += results[roundIndex].star;
            starLb.text = stars + "icon_star";

            roundIndex++;
            if (roundIndex < results.Length && results[roundIndex] != null)
            {
                SpinWheel();
            }
            else
            {
                NGUITools.SetActive(objBlock, false);
            }
        }
    }

    private void SpinWheel()
    {
        Service.Get<SignalManager>().spinWheelSignal.Dispatch(
                    new SpinWheelParameter((RoundType)roundIndex, results[roundIndex]));
    }
}
