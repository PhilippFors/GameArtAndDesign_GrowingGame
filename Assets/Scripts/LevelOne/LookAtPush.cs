using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPush : MonoBehaviour, ILookAtHandler
{

	public void OnLookatEnter()
	{
		
        UIManager.Instance.AddToSubtitleQueue("The ball is lined up and looks ready.");
	}

	public void OnLookatExit()
	{
		
	}

	public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
	{
		GetComponent<Rigidbody>().AddForceAtPosition(lookAtDirection * 500f, lookAtPosition);
	}
}
