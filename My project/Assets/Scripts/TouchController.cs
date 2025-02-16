using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public CameraLook _Camera;
    void Start()
    {   
    }

    
    void Update()
    {
        _Camera.LockAxis = _FixedTouchField.TouchDist;
    }
}
