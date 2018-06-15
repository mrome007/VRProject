using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public InputMode ActiveMode;

	private static Player instance = null;

	public GameObject ActiveFurniturePrefab;

	[SerializeField]
	private float playerSpeed = 3.0f;
	
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

	private void Update()
	{
		TryWalk();
	}

	public void TryWalk()
	{
		if(Input.GetMouseButton(0) && ActiveMode == InputMode.WALK)
		{
			var forward = Camera.main.transform.forward;
			var newPosition = transform.position + forward * Time.deltaTime * playerSpeed;
			newPosition.y = transform.position.y;
			transform.position = newPosition;
		}
	}
}

public enum InputMode
{
	NONE,
	TELEPORT,
	WALK,
	FURNITURE,
	TRANSLATE,
	ROTATE,
	SCALE
}
