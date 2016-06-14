using UnityEngine;
using System.Collections;

public class SlotView : MonoBehaviour 
{
    public UISprite bg;
    public UISprite icon;
    public UILabel label;

    private RewardInfo data;

    public void Show(RewardInfo data, int roundIndex)
    {
        this.data = data;

        bg.spriteName = roundIndex + "_" + (int)data.type;
        bg.MakePixelPerfect();

        label.text = string.Empty;
        icon.spriteName = string.Empty;

        switch(data.type)
        {
            case RewardType.DEAD_SLOT:
                SetIcon("dead");
                break;

            case RewardType.EXP:
                label.text = data.exp + " exp";
                break;

            case RewardType.GIFT:
                SetIcon(roundIndex + "_gift");
                break;

            case RewardType.JACKPOT:
                SetIcon("jackpot");
                break;

            case RewardType.MINI_GAME:
                label.text = "GAME";
                break;

            case RewardType.MORE_TURN:
                label.text = string.Format("+{0} TURN", data.turn);
                break;

            case RewardType.STAR:
                label.text = data.star + "icon_star";
                break;

            case RewardType.UP:
                label.text = "UP icon_up";
                break;
        }
    }

    public int GetRewardId()
    {
        return data.id;
    }

    private void SetIcon(string name)
    {
        icon.spriteName = name;
        icon.MakePixelPerfect();
    }
}
