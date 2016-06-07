using UnityEngine;
using System.Collections;

public class MainBoot : MonoBehaviour 
{

	// Use this for initialization
	private void Start () 
    {
        Debug.Log("START");
        Application.LoadLevel("Game");
	}
}
