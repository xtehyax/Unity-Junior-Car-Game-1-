using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Camera follows the vehicle
    public GameObject player;
    private Vector3 offset = new Vector3(0.16f, 4.35f, -5.74f); //Sets camera to follow vehicle

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() //LateUpdate is called after all Update functions have been called - fixes the jittery car movement
    {
        transform.position = player.transform.position + offset;
    }
}
