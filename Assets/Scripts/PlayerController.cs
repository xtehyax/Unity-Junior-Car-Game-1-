using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    public float speed = 20.0f;
    public float turnSpeed = 45.0f;
    public float horizontalInput;
    public float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Make the car move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);    //Time.deltaTime is the time between frames so you don't go faster at higher framerates

        //Turn the car
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); 
    }
}
