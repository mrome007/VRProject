using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableObject : MonoBehaviour 
{
	public bool IsTransformable;

	public virtual void OnGazeEnter(RaycastHit hit)
	{
		Debug.Log("Gaze entered on " + gameObject.name);
	}

	public virtual void OnGaze(RaycastHit hit)
	{
		Debug.Log("Gaze hold on " + gameObject.name);
	}

	public virtual void OnGazeExit()
	{
		Debug.Log("Gaze exited on " + gameObject.name);
	}

	public virtual void OnPress(RaycastHit hit)
	{
		Debug.Log("Button Press");
	}

	public virtual void OnHold(RaycastHit hit)
	{
		Debug.Log("Button Hold");

		if(IsTransformable)
		{
			GazeTransform(hit);
		}
	}

	public virtual void OnRelease(RaycastHit hit)
	{
		Debug.Log("Button Released");
	}

	public virtual void GazeTransform(RaycastHit hit)
	{
		switch(Player.Instance.ActiveMode)
		{
			case InputMode.TRANSLATE:
				GazeTranslate(hit);
				break;
			case InputMode.ROTATE:
				GazeRotate(hit);
				break;
			case InputMode.SCALE:
				GazeScale(hit);
				break;
		}
	}

	public virtual void GazeTranslate(RaycastHit hit)
	{
		if(hit.collider != null && hit.collider.GetComponent<Floor>())
		{
			transform.position = hit.point;
		}
	}

	public virtual void GazeRotate(RaycastHit hit)
	{

	}

	public virtual void GazeScale(RaycastHit hit)
	{

	}
}
