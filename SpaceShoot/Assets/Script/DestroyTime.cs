﻿using UnityEngine;
using System.Collections;

public class DestroyTime : MonoBehaviour {
	public float lifetime;

	// Use this for initialization
	void Start () {

		Destroy (gameObject,lifetime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
