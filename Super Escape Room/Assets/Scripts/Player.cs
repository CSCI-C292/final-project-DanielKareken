using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //for camera rotation
    float _mouseSensitivity = 5f;
    float _currentTilt = 0f;

    [SerializeField] Camera _cam;

    [SerializeField] RuntimeData _runtimeData;
    
    //for player movement
    Vector3 movementVec;
    float _moveSpeed = 6f;
    float _jumpForce = 6f;
    float verticalVelocity;
    float gravity = 20f;

    //event variables
    bool locked;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        locked = false;

        GameEvents.NoteDisplay += OnDisplay;
        GameEvents.ShowPuzzleDisplay += OnDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        //allow these actions
        if (!locked)
        {
            Aim();
            Movement();
            Jump();
            //Crouch();
        }

        else {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameEvents.InvokeDisplayHide();
                OnDisplayHide();
            }
        }
    }

    //allows player to rotate camera
    void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");        

        //allows mouse to pan camera
        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);

        //allows mouse to tilt cam up and down, but restricts to 180 degrees on y axis using clamp
        _currentTilt -= mouseY * _mouseSensitivity;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);

        _cam.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);           
        //_cam.transform.Rotate(Vector3.right, mouseY * _mouseSensitivity);
    }

    //allows player to move
    void Movement()
    {
        Vector3 sideMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 forwardMovement = transform.forward * Input.GetAxis("Vertical");
        movementVec = sideMovement + forwardMovement;
        movementVec *= _moveSpeed * Time.deltaTime;

        ApplyGravity();

        GetComponent<CharacterController>().Move(movementVec);
    }

    //for player jump
    void ApplyGravity()
    {
        if (GetComponent<CharacterController>().isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;

            Jump();
        }

        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        movementVec.y = verticalVelocity * Time.deltaTime;
    }
    
    //allows player to jump
    void Jump()
    {
        if (GetComponent<CharacterController>().isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = _jumpForce;
        }
    }

    void OnDisplay(object sender, EventArgs args)
    {
        locked = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnDisplayHide()
    {
        locked = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
