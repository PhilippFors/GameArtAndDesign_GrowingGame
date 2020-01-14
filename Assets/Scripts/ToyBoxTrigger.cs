using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBoxTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject pyramid;
    [SerializeField] private GameObject cube;
    public Transform guide;

    public SphereTrigger sphereCol;
    public PyramidTrigger pyramidCol;
    public CubeTrigger cubeCol;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals(sphere.name))
        {
            if (sphereCol.triggered)
            {
                GameManager.Instance.sphereIn = true;
                sphere.SetActive(false);
            } else
            {
             //sphere.GetComponent<Rigidbody>().useGravity = true;
             //sphere.GetComponent<Rigidbody>().isKinematic = false;
             //sphere.transform.parent = null;
             //sphere.transform.position = guide.transform.position;
                sphere.transform.position = new Vector3(1.6f, -0.0680f, 1.105567f);
            }
        }
        if (other.gameObject.name.Equals(pyramid.name))
        {
            if (pyramidCol.triggered)
            {
                GameManager.Instance.pyramidIn = true;
                pyramid.SetActive(false);
            }
            else
            {
             //pyramid.GetComponent<Rigidbody>().useGravity = true;
             //pyramid.GetComponent<Rigidbody>().isKinematic = false;
             //pyramid.transform.parent = null;
             //pyramid.transform.position = guide.transform.position;
                pyramid.transform.position = new Vector3(2.275f, 0.051f, 1.210216f);
            }
        }
        if (other.gameObject.name.Equals(cube.name))
        {
            if (cubeCol.triggered)
            {
                GameManager.Instance.cubeIn = true;
                cube.SetActive(false);
            }
            else
            {
              // cube.GetComponent<Rigidbody>().useGravity = true;
              // cube.GetComponent<Rigidbody>().isKinematic = false;
              // cube.transform.parent = null;
              // cube.transform.position = guide.transform.position;
                cube.transform.position = new Vector3(1.916f, -0.07806202f, 1.216509f);

            }
        }
    }
}
