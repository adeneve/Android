using UnityEngine;
using System.Collections;


public class ColorChange : MonoBehaviour {

	public Color color;
	public GameObject projectile;
	public GameObject gridPiece;
	public GameObject player;
	public Transform gridPieceTransform;
	public Transform projectileTransform;
	public SpriteRenderer projRender;
	public SpriteRenderer gridRender;
	public Rigidbody2D projRidg;
	public string gridIndex;
	public int index = 0;

	public float xForce;
	public float yForce;
	public float x1Force;
	public float y1Force;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");

		projectile = GameObject.Find("projectile");
		projRender = projectile.GetComponent<SpriteRenderer> ();
		projRender.color = Color.red;

		projRidg = projectile.GetComponent<Rigidbody2D> ();
		if (this.name == "projectile") {
			projRidg.AddForce (new Vector2 (xForce, yForce));

		}
		if (this.name == "projectile (1)") {
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2(x1Force, y1Force));
		}

	}
	
	// Update is called once per frame
	//iterate through each grid piece and see if the projectile position is touching a grid
	void Update () {



		/*while (index <= 8) {
			gridIndex = "grid (" + index + ")";
			gridPiece = GameObject.Find (gridIndex);
			gridPieceTransform = gridPiece.GetComponent<Transform> ();
			projectileTransform = projectile.GetComponent<Transform> ();
			gridRender = gridPiece.GetComponent<SpriteRenderer> ();
			if (Mathf.Abs (gridPieceTransform.position.x - projectileTransform.position.x) <= 0.5 && Mathf.Abs (gridPieceTransform.position.y - projectileTransform.position.y) <= 0.5) {
				gridRender.color = projRender.color;
			}
			index = index + 1;
		}

		index = 0;*/
}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "player") {
			Destroy (this.gameObject);
		} else {
			gridPiece = col.gameObject;
			gridRender = gridPiece.GetComponent<SpriteRenderer> ();
			gridRender.color = projRender.color;
		}
		
	
	}
	public void OnTriggerEnter2D(Collider2D col){
		gridPiece = col.gameObject;
		gridRender = gridPiece.GetComponent<SpriteRenderer> ();
		gridRender.color = projRender.color;
	}


}
