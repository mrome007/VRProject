using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GazeableButton : GazeableObject
{	
	protected VRCanvas parentPanel;

	private void Start()
	{
		parentPanel = GetComponentInParent<VRCanvas>();
	}
	
	public override void OnPress(RaycastHit hit)
	{
		base.OnPress(hit);
		if(parentPanel != null)
		{
			parentPanel.SetActiveButton(this);
		}
		else
		{
			Debug.LogError("Button not a child of object with VRPanel component.", this);
		}
	}

	public void SetButtonColor(Color buttonColor)
	{
		GetComponent<Image>().color = buttonColor;
	}
}
