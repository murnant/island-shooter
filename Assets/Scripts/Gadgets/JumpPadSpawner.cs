using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadSpawner : MonoBehaviour
{
public float cooldown = 10f;
private float timer = 0f;
public GameObject prefab;

public Transform groundCheck;
public float groundDistance = 0.4f;
bool isGrounded;
// Start is called before the first frame update
void Start()
{
    
}
// Update is called once per frame
void Update()
{
    isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance);
    timer -= Time.deltaTime;
    if(Input.GetKeyDown(KeyCode.Q) && timer <= 0 && isGrounded)
    {
        Instantiate(prefab,transform.position + new Vector3(0f,-1.85f,0f),transform.rotation);
        timer = cooldown;
    }
}
}
