using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float xVel = 0f;
    public float yVel = 0f;
    public bool canJump = true;
    public bool canDash = true;
    public Vector3 mouse;
    public float mouseAngle;
    private float M;
    private bool grounded;
    private bool rightWall;
    private bool leftWall;
    private float mouseX;
    private float mouseY;
    private int timer;
    private float standardVelocity = 0.05f;
    private int dashTimer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dashTimer -= 1;
        if (grounded)
        {
            canDash = true;
            canJump = true;
        }

        
        if (Input.GetKeyDown("q") && (canDash == true))
        {
            dashTimer = 5;
            rb.AddForce(new Vector2(-1500f, 0f));
            canDash = false;
        }
        if (Input.GetKeyDown("e") && (canDash == true))
        {
            dashTimer = 5;
            rb.AddForce(new Vector2(1500f, 0f));
            canDash = false;
        }
            
        
        if (Input.GetKeyDown("w") && canJump == true)
        {
            print(rightWall);
            if (rightWall)
            {
                rb.velocity = new Vector2(-5f, rb.velocity.y+5f);
                //rb.AddForce(new Vector2(-150f, 300f));
                rightWall = false;
            }
            else
            {
                rb.AddForce(new Vector2(0f, 300f));
            }
            canJump = false;
            

        }

        if (Input.GetKeyDown("d"))
        {
            if (rb.velocity.x < standardVelocity )
            {
                rb.AddForce(new Vector2(500f, 0f));
            }
            
        }
        if (Input.GetKeyDown("a"))
        {
            if (rb.velocity.x < standardVelocity )
            {
                rb.AddForce(new Vector2(-500f, 0f));
            }
        }
        if (Input.GetKeyUp("d") && (rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        if (Input.GetKeyUp("a") && (rb.velocity.x < 0))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (Input.GetKeyDown("l"))
        {
            rb.AddForce(new Vector2(0f, 1f));
        }
        transform.position = transform.position + new Vector3(xVel, yVel, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            Debug.Log("Do something else here");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        grounded = true;
        if (col.gameObject.tag == "rightWall")
        {
            rightWall = true;
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        grounded = false;
        canJump = false;
    }
}
