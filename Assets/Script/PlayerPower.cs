using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public GameObject gravityField;
    public Vector2 gravityFieldPosition;
    public bool gravityFieldOn = false;
    GameObject field;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gravityFieldOn = true;
            gravityFieldPosition = new Vector2(0, 0);
            field = Instantiate(gravityField, gravityFieldPosition, transform.rotation);
        }
        if (Input.GetMouseButtonUp(0))
        {   
            gravityFieldOn = false;
            Destroy(field);
        }
    }
}
