using UnityEngine;
using System.Collections;

// Attach this to a FirstPersonGameController's Camera in order to interact with objects by looking at them.
// Works together with ILookAtHandler
public class LookAtInteraction : MonoBehaviour
{
    public float lookDistance = 10f;
    public KeyCode interactionKey = KeyCode.F;
    public Texture crossHair;
    public Texture crossHairActive;

    [HideInInspector]
    public ILookAtHandler lastLookAtObject = null;

    // Unity Message, called every frame
    void Update()
    {
        // Do a raycast to find out if players are looking at interactive objects
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;
        RaycastHit rayCastHit; // restult of raycast is stored in here

        // Perform a raycast. The physics engine traverses the ray in the scene and looks if it hits any colliders.
        // Returns true if anyhting was hit.
        if (Physics.Raycast(rayOrigin, rayDirection, out rayCastHit, lookDistance))
        {
            // See if we have hit an object that carries a ILookAtHandler component
            ILookAtHandler currentLookAtObject = rayCastHit.collider.GetComponent<ILookAtHandler>();

            if (currentLookAtObject != null)
            {
                if (lastLookAtObject == null) // if we start looking at a valid object
                {
                    currentLookAtObject.OnLookatEnter();
                    lastLookAtObject = currentLookAtObject;
                }
                else if (currentLookAtObject != lastLookAtObject) // if we switch focus from one object to another 
                {
                    lastLookAtObject.OnLookatExit();
                    currentLookAtObject.OnLookatEnter();

                    lastLookAtObject = currentLookAtObject;
                }
            }
            else if (lastLookAtObject != null) // if we stop looking at a valid object
            {
                lastLookAtObject.OnLookatExit();
                lastLookAtObject = null;
            }
        }
        else if (lastLookAtObject != null) // if we stop looking at a valid object
        {
            lastLookAtObject.OnLookatExit();
            lastLookAtObject = null;
        }

        // if user presses the interaction key while looking at a valid object
        if (Input.GetKeyDown(interactionKey) && lastLookAtObject != null)
        {
            lastLookAtObject.OnLookatInteraction(rayCastHit.point, rayDirection);
        }
    }

    // Unity Message for drawing helper objects in the scene
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * lookDistance);
    }

    // Unity Message for drawing simple, script-based GUI
    // for more complex GUI, use the UGUI system https://unity3d.com/learn/tutorials/topics/user-interface-ui
    void OnGUI()
    {
        Vector2 crossHairPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector2 crossHairSize = new Vector2(10f, 10f);

        if (lastLookAtObject == null)
            GUI.DrawTexture(new Rect(crossHairPosition, crossHairSize), crossHair);
        else
            GUI.DrawTexture(new Rect(crossHairPosition, crossHairSize), crossHairActive);
    }
}
