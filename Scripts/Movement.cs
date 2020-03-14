using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	bool movingLeft;
	public static bool gameStarted = false;
	public AudioClip tap;
	public static float startTimer = 0;

	// Use this for initialization
	void Start () {

		movingLeft = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(startTimer < 5){
			startTimer += 1 * Time.deltaTime;
		}

		if(Input.GetMouseButtonDown(0) && startTimer > 1){

			gameStarted = true;

			if(movingLeft == true){
				movingLeft = false;
			}
			else{
				movingLeft = true;
			}

			if(Player.playerAlive == true){
				Main.totalClicks += 1;
				audio.PlayOneShot(tap);
			}


		}

		if(movingLeft == true && gameStarted == true && Player.playerAlive == true){
			gameObject.transform.Rotate(0,0,152 * Time.deltaTime);
		}
		else if(movingLeft == false && gameStarted == true && Player.playerAlive == true){
			gameObject.transform.Rotate(0,0,-152 * Time.deltaTime);
		}


	
	}
}
