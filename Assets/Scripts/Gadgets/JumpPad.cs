using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
public float time = 10;
// Start is called before the first frame update
void Start()
{
}
// Update is called once per frame
void Update()
{
    time -= Time.deltaTime;
    if(time <= 0)
    {
        Destroy(gameObject);
    }
}
}
