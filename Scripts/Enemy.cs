using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	// Use this for initialization
	void Start () {


		gameObject.animation.Play("EnemyAlive");


		int randNum = Random.Range(0,12);

		if(randNum == 0){
			DirectionOne();
		}
		else if(randNum == 1){
			DirectionTwo();
		}
		else if(randNum == 2){
			DirectionThree();
		}
		else if(randNum == 3){
			DirectionFour();
		}
		else if(randNum == 4){
			DirectionFive();
		}
		else if(randNum == 5){
			DirectionSix();
		}
		else if(randNum == 6){
			DirectionSeven();
		}
		else if(randNum == 7){
			DirectionEight();
		}
		else if(randNum < 9){
			DirectionRandom1();
		}
		else{
			DirectionRandom2();
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Player.playerAlive == false){
			Destroy (gameObject,0.8f);
		}

	
	}

	void OnTriggerEnter2D(Collider2D collider){

		if(collider.CompareTag("Enemy") && Player.playerAlive == true){
			Ads.adCountdown--;
			Player.playerAlive = false;
			Main.totalDeaths += 1;
		}
		else if(collider.gameObject.CompareTag("Destroy")){
			Destroy(gameObject);
		}



	}


	void DirectionOne(){

		gameObject.rigidbody2D.AddForce(Vector2.up * 40);

	}

	void DirectionTwo(){

		gameObject.rigidbody2D.AddForce(Vector2.up * 60);
		gameObject.rigidbody2D.AddForce(Vector2.right * 60);

	}

	void DirectionThree(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * -40);
		gameObject.rigidbody2D.AddForce(Vector2.right * -40);
		
	}

	void DirectionFour(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * 30);
		gameObject.rigidbody2D.AddForce(Vector2.right * -55);
		
	}

	void DirectionFive(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * -50);
		gameObject.rigidbody2D.AddForce(Vector2.right * 20);
		
	}

	void DirectionSix(){

		gameObject.rigidbody2D.AddForce(Vector2.up * -20);
		gameObject.rigidbody2D.AddForce(Vector2.right * -50);
	}

	void DirectionSeven(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * -55);
		gameObject.rigidbody2D.AddForce(Vector2.right * -55);
	}

	void DirectionEight(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * -45);
		gameObject.rigidbody2D.AddForce(Vector2.right * 45);

	}
	void DirectionRandom1(){
		
		int rand1 = Random.Range(10, 70);
		
		int rand2 = Random.Range(-70, 70);
		
		gameObject.rigidbody2D.AddForce(Vector2.up * rand1);
		gameObject.rigidbody2D.AddForce(Vector2.right * rand2);
		
	}

	void DirectionRandom2(){
		
		int rand1 = Random.Range(-70, -10);
		
		int rand2 = Random.Range(-70, 70);
		
		gameObject.rigidbody2D.AddForce(Vector2.up * rand1);
		gameObject.rigidbody2D.AddForce(Vector2.right * rand2);
		
	}


}
