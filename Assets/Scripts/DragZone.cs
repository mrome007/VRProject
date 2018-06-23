using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragZone : GazeableObject
{
	private VRCanvas parentPanel;
	private Transform originalParent;
	private InputMode savedInputMode = InputMode.NONE;

	private void Start()
	{
		parentPanel = GetComponentInParent<VRCanvas>();
	}

	public override void OnPress(RaycastHit hit)
	{
		base.OnPress(hit);

		originalParent = parentPanel.transform.parent;
		parentPanel.transform.parent = Camera.main.transform;

		savedInputMode = Player.Instance.ActiveMode;
		Player.Instance.ActiveMode = InputMode.DRAG;
	}

	public override void OnRelease(RaycastHit hit)
	{
		base.OnRelease(hit);
		parentPanel.transform.parent = originalParent;
		Player.Instance.ActiveMode = savedInputMode;
	}
}
