using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public float distance;
    public float speed;
    public Transform followpoint;
	// Use this for initialization
	void Start () {
        //Vector3 _velocity = GetComponent<Rigidbody>().velocity;
        //_velocity.x = speed;
        //GetComponent<Rigidbody>().velocity = _velocity;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 _position;
        _position.x = transform.position.x + (followpoint.position.x - transform.position.x) * speed;
        _position.y = followpoint.position.y - distance;
        _position.z = followpoint.position.z;
        transform.position = _position;
    }
}
