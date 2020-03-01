using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public BoxCollider goalcol;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(ball.name))
        {
            GameManager.Instance.goooooooal = true;
            UIManager.Instance.ShowSubtitle("Gooooooooal!!!!", true);
            
            goalcol.isTrigger = false;
        }


    }
}
