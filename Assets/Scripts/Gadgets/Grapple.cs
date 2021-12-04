using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Vector3 grapple;
    public bool grappleOn;
    public CharacterController controller;
    public float grappleForce = 5f;
    public Camera fpsCam;
    public GameObject gun;
    private Vector3 velocity;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    bool isGrounded;
    public LineRenderer lr;
    public Transform gunTip;
    // Start is called before the first frame update
    void Start()
    {
        grappleOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward,out hit))
        {
            if(hit.transform != null)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    grapple = hit.point;
                    grappleOn = true;
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            grappleOn = false;
            gun.transform.localRotation = Quaternion.Euler(0.0f,0.0f,0.0f);
        }
        if (grappleOn)
        {
            gun.transform.LookAt(grapple);
            velocity += gun.transform.forward *grappleForce * Time.deltaTime;
        }
        velocity *= 0.99f;
        controller.Move(velocity * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance);
        if (isGrounded)
        {
            velocity *= 0f;
        }

        lr.gameObject.GetComponent<LineRenderer>().enabled = grappleOn;
    }
    void DrawRope()
    {
        lr.SetPosition(index: 0, gunTip.position);
        lr.SetPosition(index: 1, grapple);
    }
    void LateUpdate()
    {
        DrawRope();
    }
}
