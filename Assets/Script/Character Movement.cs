using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float rotationspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 

        Vector3 movementDirection  = new Vector3(horizontalInput, 0, verticalInput);

        //This will fix character movement issues on diagnal movement;
        movementDirection.Normalize();

        transform.Translate(movementDirection * Time.deltaTime * speed, Space.World);


        //Check Character is Moving
        if(movementDirection != Vector3.zero)
        {
            //Rotate Character Instantly
            //transform.forward = movementDirection;

            //for Character Smooth rotation
            Quaternion toRotaion = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotaion, rotationspeed * Time.deltaTime);
        }
    }
}
