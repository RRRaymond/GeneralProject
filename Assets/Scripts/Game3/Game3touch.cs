using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3touch : MonoBehaviour {


	private bool istouched = false;
    public AudioClip click;
	public bool checktouch(){
		return istouched;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MousePick();
	}

	void MousePick()  {  
		if(Input.GetMouseButtonDown(0))  
		{
            if (!istouched)
            {
                Debug.Log("click");
                AudioSource.PlayClipAtPoint(click, GameObject.Find("MainCamera").transform.localPosition);
            }
                
            istouched = true;
		}  
		else if (Input.GetMouseButtonUp(0)){
			istouched = false;
		}
	}  
}
