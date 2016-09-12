using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	// Use this for initialization
	public GameObject Player;
	public int index;
	string gridIndex;
	GameObject gridPiece;
	SpriteRenderer gridRender;
	Transform gridPieceTransform;
	public int xCount;
	public int yCount;
	public float yPosition;
	public Transform PlayerTransf;
	Vector3 temp;
	public float x;
	public float y;
	public float z;

	public float timeStart;
	public float TimeDiff;
	public Color playerColor;

	private bool ready;
	private bool resetTimer = false;
	void Start () {
		Player = GameObject.Find ("player");
	    yPosition = Player.transform.position.y;
		temp = new Vector3 (0, 0, 0);
		playerColor = Color.blue;


	}
	
	// Update is called once per frame
	void Update () {
		x = Player.transform.position.x;
		y = Player.transform.position.y;
		z = Player.transform.position.z;

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (yCount == 2) {
				
			} else {
				//how to make movement discrete(on key down set ready boolean to true, if it is release set to false
				//get current time and in an other conditional, once the time has gone +1 time && keypressed true, you can move.)

				//change the color of the previous square.. later take in the time spent still
				ready = true;
					
				


			}
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) == true) {
			ready = false;
		}
		if (Input.GetKey (KeyCode.UpArrow) == true && ready == true) {
			if (Time.time - timeStart >= 1f) {
				yCount++;
				ChangeColor (Player.transform.position);
				Player.transform.position = new Vector3 (x, y + 2f, z);
				timeStart = Time.time + 1f;
			}
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (yCount == 0) {

			} else {
				
				ready = true;
				

			}
		}
		if (Input.GetKeyUp (KeyCode.DownArrow) == true) {
			ready = false;
		}
		if (Input.GetKey (KeyCode.DownArrow) == true && ready == true) {
			if (Time.time - timeStart >= 1f) {
				yCount--;
				ChangeColor (Player.transform.position);
				Player.transform.position = new Vector3 (x, y - 2f, z);
				timeStart = Time.time + 1f;
			}
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (xCount == 2) {

			} else {
				ready = true;
			}
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) == true) {
			ready = false;
		}
		if (Input.GetKey (KeyCode.RightArrow) == true && ready == true) {
			if (Time.time - timeStart >= 1f) {
				xCount++;
				ChangeColor (Player.transform.position);
				Player.transform.position = new Vector3 (x + 2f, y, z);
				timeStart = Time.time + 1f;
			}
		}


		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (xCount == 0) {

			} else {
				ready = true;
			}
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) == true) {
			ready = false;
		}
		if (Input.GetKey (KeyCode.LeftArrow) == true && ready == true) {
			if (Time.time - timeStart >= 1f) {
				xCount--;
				ChangeColor (Player.transform.position);
				Player.transform.position = new Vector3 (x - 2f, y , z);
				timeStart = Time.time + 1f;
			}
		}

			
	}
	void ChangeColor(Vector3 area){
	
		while (index <= 8) {
			gridIndex = "grid (" + index + ")";
			gridPiece = GameObject.Find (gridIndex);
			gridPieceTransform = gridPiece.GetComponent<Transform> ();
			gridRender = gridPiece.GetComponent<SpriteRenderer> ();
			if (Mathf.Abs (gridPieceTransform.position.x - area.x) <= 0.5 && Mathf.Abs (gridPieceTransform.position.y - area.y) <= 0.5) {
				gridRender.color = playerColor;
			}
			index = index + 1;
		}

		index = 0;

	}

	float CalcTime(){
		return Time.time - timeStart;

	}
}
