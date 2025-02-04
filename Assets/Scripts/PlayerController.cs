using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    [SerializeField] float horsePower = 40.0f;
    [SerializeField] float turnSpeed = 45.0f;
    public float horizontalInput;
    public float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Make the car move forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);    //Time.deltaTime is the time between frames so you don't go faster at higher framerates
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower); //AddRelativeForce is a physics based movement

        //Turn the car
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); 
    }
}
