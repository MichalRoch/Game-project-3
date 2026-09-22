using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    public float movementSpeed = 10f;
    public float runningSpeed = 5f;

    public float vertical = 0f;
    public float horizontal = 0f;

    public float currentHeight = 0f;
    public float jumpHeight = 10f;

    public float sensitivity = 3f;
    public float verticalRange = 90f;
    public float mouseVertical = 0f;
    public float mouseHorizontal = 0f;

    public float pushPower = 2F;

    public MenuInGame gameMenu;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (gameMenu.paused == false)
        {
        KeyboardController();
        MouseController();
        }
    }

    void KeyboardController()
    {
        vertical = Input.GetAxis("Vertical") * movementSpeed;
        horizontal = Input.GetAxis("Horizontal") * movementSpeed;

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            currentHeight = jumpHeight;
        }
        else
        {
            currentHeight += Physics.gravity.y * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed += runningSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed -= runningSpeed;
        }

        Vector3 move = new Vector3(horizontal, currentHeight, vertical);
        move = transform.rotation * move;
        characterController.Move(move * Time.deltaTime);
    }

    void MouseController()
    {
        mouseHorizontal = Input.GetAxis("Mouse X") * sensitivity;
        mouseVertical -= Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(0, mouseHorizontal, 0);

        mouseVertical = Mathf.Clamp(mouseVertical, -verticalRange, verticalRange);
        Camera.main.transform.localRotation = Quaternion.Euler(mouseVertical, 0, 0);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic) 
        {
            return;
        }

        if (hit.moveDirection.y < -0.3F)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;

        if (hit.gameObject.tag == "Enemy")
        {
            Debug.Log("Wykryto obeikt o tagu Enemy! Nazwa: " + hit.gameObject.tag);
        }
    }
}
