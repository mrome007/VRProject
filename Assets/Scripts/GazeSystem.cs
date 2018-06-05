using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSystem : MonoBehaviour 
{
	private void Update()
	{
		ProcessGaze();
	}
	
	public void ProcessGaze()
	{
		var ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit))
		{

		}
	}
}
