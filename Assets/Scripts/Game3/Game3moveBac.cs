using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3moveBac : MonoBehaviour {


	public Transform m_bacground;

	// Use this for initialization
	void Start () {
		
	}

	//void OnBecameInvisible()  
	//{  
	//	Destroy(this.gameObject);  
	//} 

	bool f = true;

	// Update is called once per frame
	void Update () {
		GameObject m_camera = GameObject.Find("MainCamera");
		if (f && m_camera.transform.position.y - this.transform.position.y > 6) {
			f = false;
			Vector3 new_position = this.transform.position;
			new_position.y += 26.5f;
			Object cloneObj = Instantiate (m_bacground, new_position, Quaternion.identity);
		}
	}
}
