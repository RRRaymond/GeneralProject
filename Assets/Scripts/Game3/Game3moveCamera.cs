using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3moveCamera : MonoBehaviour {
    public float move;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
    }
	
	// Update is called once per frame
	void Update () {
		var pos = this.transform.position;
        pos.x = this.transform.position.x + (player.transform.position.x - this.transform.position.x) * move;
        pos.y = this.transform.position.y + (player.transform.position.y - this.transform.position.y + 3) * move;
		this.transform.position = pos;
	}
}
