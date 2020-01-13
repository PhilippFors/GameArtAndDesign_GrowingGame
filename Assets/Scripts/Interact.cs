using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Camera camera;
    [SerializeField] private string selectable = "Selectable";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectable))
                {
                    GameManager.Instance.Growing();
                }
            }
        }
    }
}
