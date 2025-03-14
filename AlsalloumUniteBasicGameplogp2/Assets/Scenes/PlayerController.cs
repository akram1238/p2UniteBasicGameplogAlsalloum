using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public bool mainActive;
    public Camera mainCamera;
    public Camera firstPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainActive = true;
        mainCamera.enabled = true;
        firstPersonCamera.enabled = false;
    }
    private float speed = 20;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Move the vehicl forword based on Vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotates the car  based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        if (Input.GetKeyDown("space"))
        {
            if (mainActive == true)
            {
                mainCamera.enabled = false;
                firstPersonCamera.enabled = true;
                mainActive = false;
            }
            else
            {
                firstPersonCamera.enabled = false;
                mainCamera.enabled = true;
                mainActive = true;
            }
        }
    }
}
