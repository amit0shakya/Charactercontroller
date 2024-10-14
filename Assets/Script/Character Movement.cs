using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

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

        transform.Translate(movementDirection * Time.deltaTime * speed);
    }
}
