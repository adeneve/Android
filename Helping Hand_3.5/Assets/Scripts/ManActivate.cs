using UnityEngine;
using System.Collections;


public class ManActivate : MonoBehaviour {

    public GameObject player;
    public float distance=5;
    Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {

    
    player = GameObject.Find("Boy_Side_Idle (1)");
    anim = GetComponent<Animator>();
    

	}
	
	// Update is called once per frame
	void Update () {

        if (Vector2.Distance(player.transform.position, transform.position) < distance)
        {
            anim.SetInteger("State", 1);
        }else
        {
            anim.SetInteger("State", 0);
        }
	
	}
}
