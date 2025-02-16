using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    private CharacterController controller;
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 PlayerMove = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        if (PlayerMove.magnitude > 1)
        {
            PlayerMove = PlayerMove.normalized;
        }
        controller.Move(PlayerMove * SpeedMove * Time.deltaTime);
    }
}
