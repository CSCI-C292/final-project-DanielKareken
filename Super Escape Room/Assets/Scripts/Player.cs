using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //for camera rotation
    float _mouseSensitivity = 5f;
    float _currentTilt = 0f;

    [SerializeField] Camera _cam;

    [SerializeField] RuntimeData _runtimeData;

    [SerializeField] GameObject camPos;
    [SerializeField] GameObject crouchPos;
    [SerializeField] GameObject secretPos;

    [SerializeField] AudioSource walkingSound;

    CharacterController character;
    
    //for player movement
    Vector3 movementVec;
    public float maxMoveSpeed = 6f;
    float currentMoveSpeed;
    public float jumpForce = 6f;
    float verticalVelocity;
    public float gravity = 20f;
    public bool crouching;
    public float height;

    //event variables
    public bool locked;
    
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        locked = false;
        crouching = false;
        character.height = height;
        currentMoveSpeed = maxMoveSpeed;

        GameEvents.NoteDisplay += OnDisplay;
        GameEvents.ShowPuzzleDisplay += OnDisplay;
        GameEvents.LevelComplete += OnLevelComplete;
    }

    // Update is called once per frame
    void Update()
    {
        //allow these actions
        if (!locked)
        {
            Aim();
            Movement();
            Crouch();
        }

        else {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameEvents.InvokeDisplayHide();
                OnDisplayHide();
            }

            walkingSound.Stop();
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
        movementVec *= currentMoveSpeed * Time.deltaTime;

        ApplyGravity();

        
        character.Move(movementVec);

        if (character.velocity.x != 0f || character.velocity.z != 0f)
        {
            if (character.isGrounded && !walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
        }
        else
        {
            walkingSound.Stop();
        }
    }

    //for player jump
    void ApplyGravity()
    {
        if (character.isGrounded)
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
        if (character.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
    }

    //allows player to crouch
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouching)
            {
                crouching = false;
             
            }
            else
            {
                crouching = true;
            }
        }

        if (crouching)
        {
            _cam.transform.position = Vector3.Lerp(_cam.transform.position, crouchPos.transform.position, Time.deltaTime * 5f);
            //transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            currentMoveSpeed = maxMoveSpeed / 2;
            //character.height = height / 2;   
        }
        else
        {
            _cam.transform.position = Vector3.Lerp(_cam.transform.position, camPos.transform.position, Time.deltaTime * 5f);
            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            currentMoveSpeed = maxMoveSpeed;
            //character.height = height;
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

    //when player exits through door, level is completed
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Exit")
        {
            //next level
            GameEvents.InvokeLevelOver("complete");
        }
    }

    public void teleport()
    {
        character.enabled = false;
        transform.position = secretPos.transform.position;
        character.enabled = true;
    }

    void OnLevelComplete(object sender, EventArgs args)
    {
        locked = true;
        Cursor.lockState = CursorLockMode.Confined;

        GameEvents.NoteDisplay -= OnDisplay;
        GameEvents.ShowPuzzleDisplay -= OnDisplay;
        GameEvents.LevelComplete -= OnLevelComplete;
    }
}
