﻿using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Destroy(gameObject, 0.6f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
