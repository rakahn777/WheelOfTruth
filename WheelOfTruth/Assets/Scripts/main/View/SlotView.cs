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

        label.text = data.star + "star";

        icon.spriteName = string.Empty;
    }

    public int GetRewardId()
    {
        return data.id;
    }
}
