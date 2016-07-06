using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    // Use this for initialization

    public float speedX;
    public float JumpSpeedY;
    private float speed;
    private double timer;

    public bool Jumping = false;
    public bool FacingRight;
    public float startTime = 0;
    public float secondaryTime = 0;
    Animator anim;
    Rigidbody2D rb;
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        FacingRight = true;
	}
	
	// Update is called once per frame
	void Update () {

        MovePlayer(speed);


        if(Input.GetKeyDown(KeyCode.D))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.D)) 
        {
            speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            speed =-speedX;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            timer = 0.2;
            
        }
        if (timer > 0)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                rb.AddForce(new Vector2(rb.velocity.x, JumpSpeedY));
                timer = 0;
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    rb.AddForce(new Vector2(rb.velocity.x, JumpSpeedY * 1.4f));
                }
            }
        }
       

    }
    

    public void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);

        if (speed > 0 && !FacingRight || speed < 0 && FacingRight)
        {
            FlipPlayerX();
        }
        if(playerSpeed == 0 && rb.velocity.y == 0)
        {
            anim.SetInteger("State", 0);
        }
        if(playerSpeed <0 || playerSpeed>0)
        {
            anim.SetInteger("State", 1);
        }
    }
    public void FlipPlayerX()
    {
        FacingRight = !FacingRight;
        Vector3 temp = transform.localScale;
        temp.x = -temp.x;
        transform.localScale = temp;
        
    }
}
