using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	private static Player instance = null;
	
	public static Player Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType<Player>();
			}
			return instance;
		}
	}

	private void Awake()
	{
		if(instance != null)
		{
			GameObject.Destroy(instance.gameObject);
		}

		instance = this;
	}
}

public enum InputMode
{
	NONE,
	TELEPORT,
	WALK
}
