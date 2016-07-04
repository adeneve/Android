using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    // Use this for initialization

    public float speedX;
    public float JumpSpeedY;
    private float speed;

    public bool Jumping = false;
    public bool FacingRight;
    public float startTime = 0;
    public float secondaryTime = 0;
    Animator anim;
    Rigidbody2D rb;
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

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
            if ( startTime ==0 )
            {
                startTime = Time.time;
                secondaryTime = Time.time;
            }
            if (Time.time-startTime>0.3)
            {
                rb.AddForce(new Vector2(rb.velocity.x, JumpSpeedY));
                startTime = 0;
                
            }
            
        }
        if (Input.GetKeyUp(KeyCode.W)&& Time.time -startTime <0.3)
        {
            rb.AddForce(new Vector2(rb.velocity.x, Time.time - startTime * 1000));
            startTime = 0;
            
        }
       

    }

    public void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }
}
