using UnityEngine;
using System.Collections;

public class WheelView : MonoBehaviour 
{
    public Transform wheelContainer;
    public int numOfSlots;
    public AnimationCurve curve;
    public int minLap;
    public int maxLap;
    public float maxSpeed;

    // Test
    public UILabel lb;

    private float slotWidth;
    private float curAngle;
    private float cacheTargetAngle;

    private const int CIRCLE_ANGLE = 360;
    
    private void Awake()
    {
        curAngle = 0;

        // Test
        Init();
    }

    public void Init()
    {
        slotWidth = (float)CIRCLE_ANGLE / numOfSlots;
    }

    public void SetNumberOfSlots(int numOfSlots)
    {
        this.numOfSlots = numOfSlots;

        Init();
    }

    // Test
    public void StartSpin()
    {
        StartCoroutine(Roll(GetStep(GetAngle(3))));
    }

    private int GetAngle(int index)
    {
        float _angle = 0;
        for (int i = 0; i < index; i++)
        {
            _angle += slotWidth;
        }
        Debug.Log(_angle + " -> " + (_angle + slotWidth));
        _angle += Random.Range(1, slotWidth);
        Debug.Log(_angle);
        return (int)_angle;
    }

    private int GetStep(int angle)
    {
        cacheTargetAngle = angle;

        int steps = CIRCLE_ANGLE - (int)curAngle;
        steps += CIRCLE_ANGLE * Random.Range(minLap, maxLap + 1);
        steps += angle;

        return steps;
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

        curAngle = cacheTargetAngle;
        wheelContainer.eulerAngles = new Vector3(0, curAngle, 0);
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
