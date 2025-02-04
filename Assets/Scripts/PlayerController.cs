using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    [SerializeField] float horsePower = 40.0f;
    [SerializeField] float turnSpeed = 45.0f;

    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;

    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    public float horizontalInput;
    public float forwardInput;
    private Rigidbody playerRb;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;


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
        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower); 

            //Turn the car
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            //Speedo
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + "mph");

            //RPM
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }

    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround >= 1)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }
}

