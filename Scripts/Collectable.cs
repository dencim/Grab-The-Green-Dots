using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public GameObject collectExplosion;
	public static bool collectedDot;
		

	// Use this for initialization
	void Start () {
		
		
		gameObject.animation.Play("EnemyAlive");
		
		
		int randNum = Random.Range(0,9);
		
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
		else if(randNum < 6){
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
			//player collected green dot
			Main.score += 1;
			Main.circlesCollected += 1;
			Main.collectedDot = true;
			Instantiate(collectExplosion, gameObject.transform.position, new Quaternion(Random.Range(0,90),Random.Range(0,90),0,0));
			Destroy(gameObject);
		}
		else if(collider.gameObject.CompareTag("Destroy")){
			Destroy (gameObject);
		}
		

		
	}
	
	
	void DirectionOne(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * -50);
		gameObject.rigidbody2D.AddForce(Vector2.right * 30);
		
	}
	
	void DirectionTwo(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * 20);
		gameObject.rigidbody2D.AddForce(Vector2.right * -70);
		
	}
	
	void DirectionThree(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * -27);
		gameObject.rigidbody2D.AddForce(Vector2.right * -35);
		
	}
	
	void DirectionFour(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * 7);
		gameObject.rigidbody2D.AddForce(Vector2.right * -48);
		
	}
	
	void DirectionFive(){
		
		gameObject.rigidbody2D.AddForce(Vector2.up * -5);
		gameObject.rigidbody2D.AddForce(Vector2.right * 75);
		
	}

	void DirectionRandom1(){

		int rand1 = Random.Range(5, 70);

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
