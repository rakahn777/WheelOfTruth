using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class MainBoot : ContextView 
{
    private void Awake()
    {
        if (Context.firstContext == null)
        {
            context = new MainContext(this);
            ContextView.obj = this.gameObject;
        }
    }

	// Use this for initialization
	private void Start () 
    {
        Debug.Log("START");
        Application.LoadLevel("Login");
	}
}
