using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    public GameObject Plane;
    public float spawnRate = 5;
    private float timer = 0;
    public float heightOffset = 15;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        //Hämta från logicscript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnPlane();
    }

    // Update is called once per frame
    void Update()
    {
        //Kollar så spelet fortfarande igång
        if (logic.gameOn == true)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnPlane();
                timer = 0;
            }
        }      
    }

    void spawnPlane()
    { 
        float highestPoint = transform.position.y - heightOffset;
        float lowestPoint = transform.position.y + heightOffset;
        Instantiate(Plane, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
