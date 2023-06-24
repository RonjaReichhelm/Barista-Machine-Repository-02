using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class ZoomCam : MonoBehaviour
{
    
    public LensSettings m_Lens;
    public CinemachineVirtualCamera m_Camera;
    public float zoom_limit_near = 20;
    public float zoom_limit_far = 20;
    public float zoom_speed = 2;

    //This script handles the zooming in this demonstrator

    // Start is called before the first frame update
    void Start()
    {

        //  m_Lens = GetComponent<LensSettings>();

        m_Camera = GetComponent<CinemachineVirtualCamera>();
        m_Camera.m_Lens.FieldOfView = 100;
        
    }

    private void LateUpdate()
    {
        zoomCamera();
        if (Input.GetMouseButtonDown(2)) // 2 steht für die mittlere Maustaste
        {
            m_Camera.m_Lens.FieldOfView = 100;
        }
    }

    private void zoomCamera()
    {
        float wheel_Axis = Input.mouseScrollDelta.y;
        float currentFOV = m_Camera.m_Lens.FieldOfView;

        if(wheel_Axis != 0)
        {
            if (wheel_Axis > 0 && (currentFOV - 1 > zoom_limit_far))
            {
                m_Camera.m_Lens.FieldOfView -= zoom_speed;
            }

            if (wheel_Axis < 0 && (currentFOV + 1 < zoom_limit_near))
            {
                m_Camera.m_Lens.FieldOfView += zoom_speed ;
            } ;
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        zoomCamera();
        // Debug.Log(Input.mouseScrollDelta.y);
    }
}