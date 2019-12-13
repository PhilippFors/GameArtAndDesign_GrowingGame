using UnityEngine;
using System.Collections;

public class LookAtBox : MonoBehaviour, ILookAtHandler {

    public Color hoverColor = Color.white;

	public void OnLookatEnter()
	{
		this.GetComponent<Renderer>().material.SetColor("_EmissionColor", hoverColor);
	}

	public void OnLookatExit()
	{
		this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
	}

	public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
	{
		Debug.Log("Interaction!");
	}
}
