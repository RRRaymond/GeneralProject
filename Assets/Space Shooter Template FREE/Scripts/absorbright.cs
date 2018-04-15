using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class absorbright : MonoBehaviour {
    public Animation absorbr;
    // Use this for initialization
    void Start () {
        Hide();
        absorbr = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
		if(stone.absorbr)
        {
            absorbr.Play();
            stone.absorbr = false;
        }
    }

    void Hide()
    {
        Color _color = GetComponent<SpriteRenderer>().color;
        _color.a = 0.0F;
        GetComponent<SpriteRenderer>().color = _color;
    }
}
