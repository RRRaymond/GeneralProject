using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3moveCamera : MonoBehaviour {

	public float speed_up = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 curpos = this.transform.position;
		curpos.y = curpos.y + speed_up * Time.deltaTime;
		this.transform.position = curpos;
	}
}
