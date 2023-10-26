using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private float x;
    private float y;
    public float ZoomAmp=60.0f;
    public float RotAmp = 60.0f;
    public Camera cam;
    private Vector3 rotateValue;
    // Start is called before the first frame update
    void Start()
    {
        cam= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.fieldOfView = ZoomAmp;
        
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        Debug.Log(x + ":" + y);
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;

    }
    public void ZoomCamera(float zoom)
    {
        ZoomAmp=zoom;
    }
  
}
