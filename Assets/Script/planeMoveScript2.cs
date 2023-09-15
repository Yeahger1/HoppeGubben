using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class planeMoveScript2 : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = 25;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public LogicScript logic;
    public PlayerPower power;
    public GameObject jumper;
    public float sideOffset = 2;
    [SerializeField] Rigidbody2D plane;
    Rigidbody2D rb2D;
    Transform target;

    public Vector2 position;
    public Vector2 velocity;
    public Vector2 acceleration;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        power = GameObject.FindGameObjectWithTag("Kropp").GetComponent<PlayerPower>();
        moveSpeed = Random.Range(1, 5);
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2D == null)
        {
            position = transform.position;
            velocity += (Vector2.right * moveSpeed * 0.005f) * Time.deltaTime;
        }
        //*-1 if gravityField is turned off
        if (power.gravityFieldOn)
        {
            plane.gravityScale = 0;
            if (power.gravityFieldPosition.x + 0.5f > transform.position.x)
            {
                velocity.x = +2 * Time.deltaTime;
            }
            if (power.gravityFieldPosition.x - 0.5f < transform.position.x)
            {
                velocity.x = -2 * Time.deltaTime;
            }
            if (power.gravityFieldPosition.y + 0.5f > transform.position.y)
            {
                velocity.y = +2 * Time.deltaTime;
            }
            if (power.gravityFieldPosition.y - 0.5f < transform.position.y)
            {
                velocity.y = -2 * Time.deltaTime;
            }
        }
        if (power.gravityFieldOn && Input.GetMouseButtonUp(0))
        {
            power.gravityFieldOn = false;
            target = GameObject.FindGameObjectWithTag("gravityField").transform;
            rb2D = GetComponent<Rigidbody2D>();
            Vector2 direction = target.position - transform.position;

            direction.Normalize();

            rb2D.velocity = (direction * 150) *-1;

            transform.right = direction;
        }

        position += velocity;
        transform.position = position;

        if (transform.position.x > deadZone)
        {
            Debug.Log("Plane destroyed");
            Destroy(gameObject);
            logic.addScore(1);
        }
        if (logic.gameOn == false)
        {
            moveSpeed = 0;
            Invoke("changeSprite", Random.Range(1, 3));
            Invoke("killPlane", Random.Range(4, 5));
        }
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //If planes colide, change picture, stop them and then destroys them
        //if (collision.gameObject.layer == 3 && power.gravityFieldOn == false)
        //{
        //    changeSprite();
        //    spawnJumper();
        //    moveSpeed = 0;
        //    Invoke("killPlane", 0.5f);
        //    logic.gameOver();
        //}
    }
    void changeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
    void killPlane()
    {
        Destroy(gameObject);
        //spawnJumper();
    }
    void spawnJumper()
    {
        for (int i = Random.Range(0, 2); i < 4; i++)
        {
            float leftSide = transform.position.x - sideOffset;
            float RightSide = transform.position.x + sideOffset;
            Instantiate(jumper, new Vector3(Random.Range(leftSide, RightSide), transform.position.y, 0), jumper.transform.rotation);
        }
    }

}

