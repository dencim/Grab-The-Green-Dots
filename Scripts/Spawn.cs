using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject enemy;
	public GameObject collectable;
	float timer = 0;
	float timer2 = 0;
	float timer3 = 0;
	float timer4 = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Player.playerAlive == true && Movement.gameStarted == true){

			timer += 1 * Time.deltaTime;
			
			if(timer > 1){
				Instantiate(enemy,new Vector2(0,0),transform.rotation);
				timer = 0;
			}
			
			timer2 += 1 * Time.deltaTime;
			
			if(timer2 > 1.25f){
				Instantiate(collectable,new Vector2(0,0),transform.rotation);
				timer2 = 0;
			}

			timer3 += 1 * Time.deltaTime;
			
			if(timer3 > 3){
				Instantiate(collectable,new Vector2(0,0),transform.rotation);
				timer3 = 0;
			}

			timer4 += 1 * Time.deltaTime;

			if(timer4 > 2.5f){
				Instantiate(enemy,new Vector2(0,0),transform.rotation);
				timer4 = 0;
			}

		}


	}
}
