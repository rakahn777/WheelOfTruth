using System;
using UnityEngine;
using System.Collections;
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property,
	AllowMultiple = true)] 
public sealed class AbilitiesAttribute : System.Attribute
{
	private string name;
	private TransferType type;

	public AbilitiesAttribute(string abilitiesName,TransferType transferType=TransferType.OVERRIDE)
	{
		this.name = abilitiesName;
		this.type = transferType;
	}

	public string GetName()
	{
		return this.name;
	}

	public TransferType GetTransferType()
	{
		return this.type;
	}
}

public enum TransferType
{
	OVERRIDE,PLUS,MINUS,PLUS_PERCENT,MINUS_PERCENT
}
