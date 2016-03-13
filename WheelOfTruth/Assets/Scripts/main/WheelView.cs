using UnityEngine;
using System.Collections;

public class WheelView : MonoBehaviour 
{
    public Transform wheelContainer;
    public AnimationCurve curve;
    public int minLap;
    public int maxLap;
    public float maxSpeed;

    public UILabel lb;

    private float curAngle;
    
    private void Awake()
    {
        curAngle = 0;
    }

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space) && curAngle == 0 )
        {
            StartCoroutine(Roll(3000));
        }
	}

    private IEnumerator Roll(int totalStep)
    {
        float step = 0;
        float tempStep = step;

        while (true)
        {
            float tmp = GetStepAngle(step, totalStep);
            tempStep += tmp;
            if (tempStep > totalStep)
            {
                tmp = totalStep - step;
                step = totalStep;
            }
            else
                step = tempStep;

            curAngle += tmp;
            if (curAngle >= 360)
                curAngle = curAngle - 360;

            wheelContainer.eulerAngles = new Vector3(0, curAngle, 0);

            yield return new WaitForSeconds(GetStepTime(step, totalStep));

            lb.text = step + " - " + curAngle + " - " + tmp;

            if (step >= totalStep)
                break;
        }
    }

    private float GetStepAngle(float step, int totalSteps)
    {
        float tmp = (maxSpeed * curve.Evaluate((float)step / totalSteps));
        return tmp > 0 ? tmp : 0.01f;
    }

    private float GetStepTime(float step, int totalSteps)
    {
        return 0.02f;
        //return maxSpeed * (1 - curve.Evaluate((float)step / totalSteps));
    }
}
