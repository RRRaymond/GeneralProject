using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roteta : MonoBehaviour {
    public float m_angle = 360;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.forward, m_angle * Time.deltaTime);
	}
}
