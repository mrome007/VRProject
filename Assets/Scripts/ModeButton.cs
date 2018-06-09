using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButton : GazeableButton
{
	[SerializeField]
	private InputMode mode;

	public override void OnPress(RaycastHit hit)
	{
		base.OnPress(hit);

		if(parentPanel.currentActiveButton != null)
		{
			Player.Instance.ActiveMode = mode;
		}
	}
}
