using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPush : MonoBehaviour, ILookAtHandler
{

	public void OnLookatEnter()
	{
		GetComponent<Renderer>().material.color = Color.magenta;
	}

	public void OnLookatExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}

	public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
	{
		GetComponent<Rigidbody>().AddForceAtPosition(lookAtDirection * 500f, lookAtPosition);
	}
}
