using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
        /*
		if(other.GetComponent<CharacterController>() != null)
			GameManager.instance.OnDeathTriggerEnter();
		else
			Destroy(other.gameObject);

        */
	}
}
