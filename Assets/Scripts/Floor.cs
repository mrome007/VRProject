using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : GazeableObject
{
	public override void OnPress(RaycastHit hit)
	{
		base.OnPress(hit);

		if(Player.Instance.ActiveMode == InputMode.TELEPORT)
		{
			var position = hit.point;
			position.y = Player.Instance.transform.position.y;
			Player.Instance.transform.position = position;
		}
	}
}
