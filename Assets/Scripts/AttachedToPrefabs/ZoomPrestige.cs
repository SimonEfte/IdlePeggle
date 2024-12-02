using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPrestige : MonoBehaviour
{
    public float zoomSpeed = 0.1f;  // Adjust the zoom speed as needed
    public static float minZoom = 0.5f;
    public static float maxZoom = 1.5f;

    public void Start()
    {
        minZoom = 0.36f;
        maxZoom = 1.44f;
    }

    void Update()
    {
        if(Prestige.isInChooseLevelScreen == false)
        {
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

            // Change the scale based on the scroll wheel input
            transform.localScale += new Vector3(scrollWheel * zoomSpeed, scrollWheel * zoomSpeed, 0);

            // Clamp the scale to stay within the specified range
            transform.localScale = new Vector3(
                Mathf.Clamp(transform.localScale.x, minZoom, maxZoom),
                Mathf.Clamp(transform.localScale.y, minZoom, maxZoom),
                Mathf.Clamp(transform.localScale.z, minZoom, maxZoom)
            );
        }
    }
}
