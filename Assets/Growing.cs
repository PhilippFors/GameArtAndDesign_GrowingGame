using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Camera camera;
    [SerializeField] private string selectable = "Selectable";
    private CharacterController charcontrol;
    void Start()
    {
        charcontrol = gameObject.GetComponent<CharacterController>();
    }

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
                    charcontrol.radius = 0.3f;
                    charcontrol.height = 1.5f;
                }
            }
        }
    }
}
