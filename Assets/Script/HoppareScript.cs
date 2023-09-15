using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppareScript : MonoBehaviour
{
    public float sideSpeed = 1;
    public float turn = 2;
    float timer = 0;
    float turnTime = 0;
    bool hopp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //För att gubbarna ska hoppa upp från planet
        if (hopp)
            transform.position = transform.position + (Vector3.up * sideSpeed * 3) * Time.deltaTime;
        if (timer < turn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            turnTime++;
            timer = 0;
            hopp = false;
        }
        if (turnTime % 2 == 0)
        {
            transform.position = transform.position + (Vector3.right * sideSpeed) * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + (Vector3.left * sideSpeed) * Time.deltaTime;
        }

    }
}
