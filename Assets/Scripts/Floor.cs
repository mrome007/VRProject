using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : GazeableObject
{
	public override void OnPress(RaycastHit hit)
	{
		base.OnPress(hit);

		switch(Player.Instance.ActiveMode)
		{
			case InputMode.TELEPORT:
				var position = hit.point;
				position.y = Player.Instance.transform.position.y;
				Player.Instance.transform.position = position;
				break;

			case InputMode.FURNITURE:
				GameObject placedFurniture = GameObject.Instantiate(Player.Instance.ActiveFurniturePrefab);
				placedFurniture.transform.position = hit.point;
				break;

			default:
				break;
		}
	}
}
