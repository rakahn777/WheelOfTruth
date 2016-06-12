using UnityEngine;
using System.Collections;

public class AutoScaleSize : MonoBehaviour
{
    private readonly float DEFAULT_RATIO = 16f / 9;
	// Use this for initialization
	void Start () 
    {
        float ratio = (float)Screen.height / Screen.width;

        transform.localScale = Vector3.one * DEFAULT_RATIO / ratio;
	}
}
