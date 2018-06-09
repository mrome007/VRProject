using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvas : MonoBehaviour 
{
	public GazeableButton currentActiveButton;

	[SerializeField]
	private Color unselectedColor = Color.white;

	[SerializeField]
	private Color selectedColor = Color.green;

	public void SetActiveButton(GazeableButton activeButton)
	{
		if(currentActiveButton != null)
		{
			currentActiveButton.SetButtonColor(unselectedColor);
		}

		if(activeButton != null && currentActiveButton != activeButton)
		{
			currentActiveButton = activeButton;
			currentActiveButton.SetButtonColor(selectedColor);
		}
		else
		{
			currentActiveButton = null;
			Player.Instance.ActiveMode = InputMode.NONE;
		}
	}
}
