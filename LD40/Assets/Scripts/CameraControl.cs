﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    GameObject player;
    public Vector3 cameraOffset;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraOffset = new Vector3(0, 30, -15);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + cameraOffset;
	}
}
