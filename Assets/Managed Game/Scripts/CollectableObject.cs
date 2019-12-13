using UnityEngine;
using System.Collections;

public class CollectableObject : MonoBehaviour, ILookAtHandler
{
    public float previewSize = 2f;

	public void OnLookatEnter()
	{
		this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
	}

	public void OnLookatExit()
	{
		this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
	}

	public void OnLookatInteraction(Vector3 lookAtPosition, Vector3 lookAtDirection)
	{
        //GameManager.instance.CollectObject(this.gameObject, previewSize);
        GetComponent<AudioSource>().Play();
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
    }
}
