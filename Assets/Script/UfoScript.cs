using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UfoScript : MonoBehaviour
{
    public float deadZone = -25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
