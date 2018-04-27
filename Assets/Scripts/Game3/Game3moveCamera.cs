using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3moveCamera : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		var pos = this.transform.position;
		pos.y = player.transform.position.y+3;
		this.transform.position = pos;
	}
}
