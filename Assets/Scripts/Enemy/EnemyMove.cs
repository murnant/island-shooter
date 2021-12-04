using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float jumphight = 2.0f;

    public CharacterController controller;
    public float speed =12.0f;
    Vector3 velocity;
    public float gravity = -9.81f;
    bool isGrounded;
    public LayerMask jumpPadLayerMask;
    public Transform Player;
    public ParticleSystem boom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move
        //transform.localRotation = Player.localRotation;
        transform.LookAt(Player);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = transform.right * x + transform.forward * z;
        Vector3 move = transform.forward;
        //if(Input.GetKey(KeyCode.LeftShift))
        //{
            //move *= 2f;
        //}
        controller.Move(move * speed * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumphight * -2.0f * gravity);
        }

        if(Physics.CheckSphere(groundCheck.position,groundDistance))
        {
            boom.Play(true);
            if(boom.particleCount >= 10)
            {
                Destroy(gameObject);
            }
        }


        //Gravity
        // isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance);
        // if (isGrounded && velocity.y < 0.0f)
        // {
            // velocity.y = -2.0f;
        // }
        // velocity.y += gravity *Time.deltaTime;
        // controller.Move(velocity * Time.deltaTime);
        // jump
        // if(Input.GetButtonDown("Jump") && isGrounded)
        // {
            // velocity.y = Mathf.Sqrt(jumphight * -2 * gravity);
        // }

        // JumpPad
        // isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,jumpPadLayerMask);
        // if (isGrounded)
        // {
            // velocity.y += gravity * -1f;
        // }
    }
}
