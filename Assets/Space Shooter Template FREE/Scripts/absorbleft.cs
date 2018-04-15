using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class absorbleft : MonoBehaviour {
    public Animation absorbl;
	// Use this for initialization
	void Start () {
        Hide();
        absorbl = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (stone.absorbl)
        {
            absorbl.Play();
            stone.absorbl = false;
        }
    }

    void Hide()
    {
        Color _color = GetComponent<SpriteRenderer>().color;
        _color.a = 0.0F;
        GetComponent<SpriteRenderer>().color = _color;
    }
}
