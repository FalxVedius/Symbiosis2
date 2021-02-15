using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private Camera indiCam;
    [SerializeField]
    private Camera jebCam;


    private float indiTargetZoom;
    private float jebTargetZoom;
    private float zoomAmount = 9f;
    private float zoomLerp = 10f;

    void Start()
    {
        indiTargetZoom = indiCam.fieldOfView;
        jebTargetZoom = jebCam.fieldOfView;
    }

    
    void Update()
    {

        float scrollWheelAmount = Input.GetAxis("Mouse ScrollWheel");

        indiTargetZoom -= scrollWheelAmount * zoomAmount;
        indiTargetZoom = Mathf.Clamp(indiTargetZoom, 40f, 80f);

        jebTargetZoom -= scrollWheelAmount * zoomAmount;
        jebTargetZoom = Mathf.Clamp(jebTargetZoom, 40f, 80f);

        indiCam.fieldOfView = Mathf.Lerp(indiCam.fieldOfView, indiTargetZoom, Time.deltaTime * zoomLerp);
        jebCam.fieldOfView = Mathf.Lerp(jebCam.fieldOfView, jebTargetZoom, Time.deltaTime * zoomLerp);
    }
}
