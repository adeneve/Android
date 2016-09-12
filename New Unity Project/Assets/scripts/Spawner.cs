using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	GameObject proj;
	void Start () {
		proj = new GameObject ();
		proj.AddComponent<Transform>();
		proj.name = "shpoop";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
