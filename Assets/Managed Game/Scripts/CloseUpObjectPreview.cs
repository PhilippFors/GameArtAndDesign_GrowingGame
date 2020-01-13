using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpObjectPreview : MonoBehaviour
{
    public Transform m_rotateRoot;
    public Camera m_camera;

    Vector3 m_lastMousePos;
    GameObject m_currentInstance = null;

    /// <summary>
    /// Give it an object to look at. Will create an instance of the object and delete it after finshing.
    /// </summary>
    public void ShowPreview(GameObject objectToLookAt, float size = 1f)
    {
        if (objectToLookAt == null)
        {
            Debug.LogWarning("No object given to look at.", this);
            return;
        }

        m_camera.enabled = true;
        m_rotateRoot.localEulerAngles = Vector3.zero;

        if (m_currentInstance != null)
            Destroy(m_currentInstance);

        // creates a copy of the game object and parents it to the rotateRoot
        m_currentInstance = Instantiate(objectToLookAt, m_rotateRoot);
        m_currentInstance.transform.localPosition = -GetLocalCenter(m_currentInstance) * size;
        m_currentInstance.transform.localEulerAngles = Vector3.zero;
        m_currentInstance.transform.localScale = Vector3.one * size;
        m_currentInstance.layer = LayerMask.NameToLayer("Object Preview");
        m_currentInstance.SetActive(true);
    }

    public void HidePreview()
    {
        m_camera.enabled = false;
        if (m_currentInstance != null)
            Destroy(m_currentInstance);
        //GameManager.instance.OnClosePreview(); // tell game manager, that the game should continue
    }

    public Vector3 GetLocalCenter(GameObject go)
    {
        Renderer[] renderers = go.GetComponentsInChildren<Renderer>();

        if(renderers.Length == 0)
        {
            return Vector3.zero;
        }

        Bounds bounds = new Bounds(); // world bounding volume

        for (int i = 0; i < renderers.Length; i++)
        {
            if (i == 0)
                bounds = renderers[i].bounds;
            else
                bounds.Encapsulate(renderers[i].bounds);
        }

        // transform the center back to local coordinates
        return go.transform.InverseTransformPoint(bounds.center);
    }

    void Update()
    {
        if (m_currentInstance != null)
        {
            Vector3 delta = Input.mousePosition - m_lastMousePos;

            m_rotateRoot.Rotate(new Vector3(delta.y, -delta.x, 0), Space.World);

            m_lastMousePos = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                HidePreview();
            }
        }
    }

    #region Accessing the object

    public static CloseUpObjectPreview instance;

    void Awake()
    {
        CloseUpObjectPreview.instance = this;
    }

    #endregion
}
