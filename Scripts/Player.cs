using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static bool playerAlive = true;
	public static bool playAnimAfterDeath = true;
	public AudioClip dead;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if(playerAlive == false && playAnimAfterDeath == true){
			gameObject.animation.Play("Dead");
			audio.PlayOneShot(dead);
			playAnimAfterDeath = false;
		}

	
	}
}
