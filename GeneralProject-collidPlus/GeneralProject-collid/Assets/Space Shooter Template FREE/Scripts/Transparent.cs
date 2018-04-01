using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour {
    //public Material _material;
	// Use this for initialization
	void Start () {
        Color _color = GetComponent<SpriteRenderer>().color;
        _color.a = 0.5F;
        GetComponent<SpriteRenderer>().color = _color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
