using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform PlayerBody;
    public Vector2 LockAxis;
    void Start()
    {
    }

    void Update()
    {
        XMove = LockAxis.x;
        YMove = LockAxis.y;
        
        XRotation -= YMove;

        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(XRotation,180,0);

        PlayerBody.Rotate(Vector3.up * XMove);
    }
}
