﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManActivate : MonoBehaviour {

    public GameObject TextBox_interact;
    public GameObject TextBox_man;
    public GameObject player;
    public float distance=5;
    Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
    TextBox_interact.SetActive(false);
    player = GameObject.Find("Boy_Side_Idle (1)");
    anim = GetComponent<Animator>();
    

	}
	
	// Update is called once per frame
	void Update () {

        if (Vector2.Distance(player.transform.position, transform.position) < distance)
        {
            anim.SetInteger("State", 1);
            TextBox_interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                TextBox_man.SetActive(true);
            }
        }else
        {
            anim.SetInteger("State", 0);
            TextBox_interact.SetActive(false);
            TextBox_man.SetActive(false);
        }
	
	}
}