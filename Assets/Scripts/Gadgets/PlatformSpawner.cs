using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float cooldown = 5f;
    private float timer = 0f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.E) && timer <= 0)
        {
            Instantiate(prefab,transform.position + new Vector3(0f,-1.85f,0f),transform.rotation);
            timer = cooldown;
        }
    }
}
