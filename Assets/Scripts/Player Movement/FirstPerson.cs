using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;
    
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 10f;
    
    
    private float _resistanceSpeed = 0;

    [SerializeField] private CharacterController _characterController;

    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Rotate();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _characterController.Move(Time.deltaTime * Speed *(_player.right * horizontal + _player.forward * vertical + 10 *Vector3.down));
        _characterController.Move(Time.deltaTime * -_resistanceSpeed * Vector3.back);
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        _camera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        _player.Rotate(mouseX * Vector3.up);
    }

    private float Speed
    {
        get
        {
            bool isRunning = Input.GetKey(KeyCode.LeftShift);

            float speed = isRunning ? _runSpeed : _walkSpeed;
            return speed;
        }
    }
    
    public void SetResistanceSpeed(float resistanceSpeed)
    {
        _resistanceSpeed = resistanceSpeed;
    }
}