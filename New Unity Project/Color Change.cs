using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer projRender;
	void Start () {
		 GameObject projectile = GameObject.Find("projectile");
		projRender = projectile.GetComponent<SpriteRenderer>();
		 projRender.color = new Color (2f, 4f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
