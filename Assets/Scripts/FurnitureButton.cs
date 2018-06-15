using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureButton : GazeableButton
{
	public GameObject furniturePrefab;

	public override void OnPress(RaycastHit hit)
	{
		base.OnPress(hit);
		Player.Instance.ActiveMode = InputMode.FURNITURE;
		Player.Instance.ActiveFurniturePrefab = furniturePrefab;
	}
}
