using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PCInputController 
{
    
    private Camera _camera;
    private bool _leftPointClicked;

    public Action<Vector3, Collider> LeftPointerClikHandler = delegate { };
    private ServiceManager _serviceManager;

   

    public  PCInputController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
        _camera = Camera.main;
       //  Time.timeScale = 1;
        _serviceManager = ServiceManager.Instance;
        _serviceManager.UpdateHandler += OnUpdate;
        _serviceManager.LateUpdateHandler += OnLateUpdate;
        _serviceManager.FixedUpdateHandler += OnFixedUpdate;
        _serviceManager.DestroyHandler += OnDestroy;

    }

    // Update is called once per frame
    void OnUpdate()
    {
        _leftPointClicked = Input.GetButton("Fire1");

    }
    private void OnLateUpdate()
    {
        
    }
    private void OnFixedUpdate()
    {
        if (_leftPointClicked)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000))
            {
                LeftPointerClikHandler(hitInfo.point, hitInfo.collider);
                
            }


        }


    }
    private void OnDestroy()
    {
        _serviceManager.UpdateHandler -= OnUpdate;
        _serviceManager.LateUpdateHandler -= OnLateUpdate;
        _serviceManager.FixedUpdateHandler -= OnFixedUpdate;
        _serviceManager.DestroyHandler -= OnDestroy;
    }
}
