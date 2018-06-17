using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableObject : MonoBehaviour 
{
	public bool IsTransformable;
	private int objectLayer;
	private const int IgnoreRaycastLayer = 2;

	private Vector3 initialObjectRotation;
	private Vector3 initialPlayerRotation;

	private Vector3 initialObjectScale;

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
		if(IsTransformable)
		{
			objectLayer = gameObject.layer;
			gameObject.layer = IgnoreRaycastLayer;

			initialObjectRotation = transform.rotation.eulerAngles;
			initialPlayerRotation = Camera.main.transform.rotation.eulerAngles;

			initialObjectScale = transform.localScale;
		}
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
		if(IsTransformable)
		{
			gameObject.layer = objectLayer;
		}
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
		float rotationSpeed = 5f;
		var currentPlayerRotation = Camera.main.transform.rotation.eulerAngles;
		var currentObjectRotation = transform.rotation.eulerAngles;

		var rotationDelta = currentPlayerRotation - initialPlayerRotation;

		var newRotation = new Vector3(currentObjectRotation.x, initialObjectRotation.y + (rotationDelta.y * rotationSpeed), currentObjectRotation.z);
		transform.rotation = Quaternion.Euler(newRotation);
	}

	public virtual void GazeScale(RaycastHit hit)
	{
		var scaleSpeed = 0.1f;
		var scaleFactor = 1f;

		var currentPlayerRotation = Camera.main.transform.rotation.eulerAngles;
		var rotationDelta = currentPlayerRotation - initialPlayerRotation;

		//if looking up.
		if(rotationDelta.x < 0 && rotationDelta.x > -180f || rotationDelta.x > 180f && rotationDelta.x < 360f)
		{
			if(rotationDelta.x > 180f)
			{
				rotationDelta.x = 360f - rotationDelta.x;
			}

			scaleFactor = 1f + Mathf.Abs(rotationDelta.x) * scaleSpeed;
		}
		else
		{
			if(rotationDelta.x < -180f)
			{
				rotationDelta.x = 360f + rotationDelta.x;
			}

			scaleFactor = Mathf.Max(0.1f, 1.0f - (Mathf.Abs(rotationDelta.x) * (1f / scaleSpeed)) / 180f);
		}

		transform.localScale = scaleFactor * initialObjectScale;
	}
}
