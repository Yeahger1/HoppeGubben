using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppeGubben : MonoBehaviour
{
    public Rigidbody2D hoppeGubben;
    public AudioSource Ujja;
    public LogicScript logic;
    Rigidbody2D Gubben;
    public float heroSpeed = 10f;
    Vector2 position = Vector2.zero;
    public float radius = 3;

    // Start is called before the first frame update
    void Start()
    {
        //Hämta från logicscript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Gubben = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * heroSpeed * Time.deltaTime;
        position.y += Input.GetAxis("Vertical") * heroSpeed * Time.deltaTime;

        transform.position = position;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
      