using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
      private float x;
      private float y;
      public bool activator;
      public float ZoomAmp=60.0f;
      public float RotAmp = 60.0f;
      public Camera cam;
      private Vector3 rotateValue;
    void Start()
    {
        cam= GetComponent<Camera>();
        activator = false;
    }

    // Update is called once per frame
    void Update()
    {
        cam.fieldOfView = ZoomAmp;
        if (activator==true) { 
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        Debug.Log(x + ":" + y);
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        }
        //for focusing the camera on an object
        if (Input.GetMouseButtonDown(0)) // Checking for a left mouse click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Checking if the hit object is the one you want to focus on : the planets ofc

                if (hit.transform.CompareTag("TrackingObject"))
                {
                    // Adjusting the camera position
                    cam.transform.position = hit.transform.position + new Vector3(0, 50, -50); // Adjusting the position as needed

                    // Making the camera look at the clicked object
                    cam.transform.LookAt(hit.transform);
                }
            }
        }

    }
    public void ZoomCamera(float zoom)
    {
        ZoomAmp=120-zoom;
    }
    public void Rotation_activator(bool activation)
    {
        activator = activation; 
    }
}
