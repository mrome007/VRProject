using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSystem : MonoBehaviour 
{
	[SerializeField]
	private GameObject reticle;

	[SerializeField]
	private Color inactiveReticleColor = Color.white;

	[SerializeField]
	private Color activeReticleColor = Color.green;

	private GazeableObject currentGazeObject;
	private GazeableObject currentSelectableObject;

	private RaycastHit lastHit;

	private void Start()
	{
		SetReticleColor(inactiveReticleColor);
	}

	private void Update()
	{
		ProcessGaze();
		CheckForInput(lastHit);
	}
	
	public void ProcessGaze()
	{
		var ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit))
		{
			var hitObject = hit.collider.gameObject;
			var gaze = hitObject.GetComponent<GazeableObject>();

			if(gaze != null)
			{
				if(gaze != currentGazeObject)
				{
					ClearCurrentObject();
					currentGazeObject = gaze;
					gaze.OnGazeEnter(hit);
					SetReticleColor(activeReticleColor);
				}
				else
				{
					currentGazeObject.OnGaze(hit);
				}
			}
			else
			{
				ClearCurrentObject();
			}

			lastHit = hit;
		}
		else
		{
			ClearCurrentObject();
		}
	}

	private void SetReticleColor(Color reticleColor)
	{
		var renderer = reticle.GetComponent<Renderer>();
		if(renderer != null)
		{
			renderer.material.SetColor("_Color", reticleColor);
		}
	}

	private void CheckForInput(RaycastHit hit)
	{
		if(Input.GetMouseButtonDown(0) && currentGazeObject != null)
		{
			currentSelectableObject = currentGazeObject;
			currentSelectableObject.OnPress(hit);
		}

		if(Input.GetMouseButton(0) && currentSelectableObject != null)
		{
			currentSelectableObject.OnHold(hit);
		}

		if(Input.GetMouseButtonUp(0) && currentSelectableObject != null)
		{
			currentSelectableObject.OnRelease(hit);
			currentSelectableObject = null;
		}
	}

	private void ClearCurrentObject()
	{
		if(currentGazeObject != null)
		{
			currentGazeObject.OnGazeExit();
			SetReticleColor(inactiveReticleColor);
			currentGazeObject = null;
		}
	}
}
