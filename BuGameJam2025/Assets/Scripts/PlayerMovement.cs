using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float currentSpeed;
    [SerializeField] float defaultSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float backwardsSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float smoothingTime = 1f;
    private float currentHorizontalVelocity;

    [SerializeField] CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private Vector3 currentDirection;

    void Start()
    {
        currentSpeed = defaultSpeed;
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        float sprint = Input.GetAxis("Sprint");

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            currentHorizontalVelocity = Mathf.Lerp(currentHorizontalVelocity, 0f, Time.deltaTime / smoothingTime);
        }
        else
        {
            currentHorizontalVelocity = moveX;
        }

        Vector3 targetDirection = transform.right * currentHorizontalVelocity + transform.forward * moveZ;
        Vector3 smoothedDirection = Vector3.SmoothDamp(currentDirection, targetDirection, ref currentDirection, smoothingTime);
        smoothedDirection.y = 0f;

        characterController.Move(smoothedDirection * currentSpeed * Time.deltaTime);

        if (jump > 0 && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (isGrounded)
        {
            if (moveZ > 0 && sprint > 0)
            {
                currentSpeed = sprint > 0 ? sprintSpeed : defaultSpeed;
            }
            else if (moveZ < 0)
            {
                currentSpeed = moveZ < 0 ? backwardsSpeed : defaultSpeed;
            }
            else
            {
                currentSpeed = defaultSpeed;
            }
        }
    }
}
