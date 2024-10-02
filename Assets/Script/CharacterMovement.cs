using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    private CharacterController controller;
    private float ySpeed;

    private float originalStepOffset;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
        originalStepOffset = controller.stepOffset;
        Debug.Log(controller.stepOffset + "<<<controller.stepOffset >>>"+ originalStepOffset);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertaicalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, vertaicalInput);
        float magnitude = movementDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);// Setting magnitude limit under 1
        //Normalize maintain consistant speed on all directions;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {

            controller.stepOffset = originalStepOffset;
            //We set ySpeed 0 just because Y is falling down very fast and chracter was falling down instantly
            ySpeed = -0.5f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ySpeed = jumpSpeed;
            }
        }
        /*else
        {
            controller.stepOffset = 0;
        }*/

        Vector3 velocity = movementDirection * magnitude * speed;
        velocity.y = ySpeed;

        controller.Move(velocity * Time.deltaTime);
        //controller.SimpleMove(velocity);
        //transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        //Let's Check if character is moving
        if (movementDirection != Vector3.zero)
        {
            //Instant Rotate Character
            // transform.forward = movementDirection;

            Quaternion toRotaion = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotaion, rotationSpeed * Time.deltaTime);
        }
    }
    }
