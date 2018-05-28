using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userName : MonoBehaviour {

    public static userName Instance;
    public static string username;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
		if (username == null) {
			GameObject.Find ("namePanel").GetComponent<CanvasGroup> ().alpha = 1;
			gameObject.GetComponent<SwitchScene>().enabled = false;
		} else {
			GameObject.Find("namePanel").GetComponent<CanvasGroup>().alpha = 0;
			gameObject.GetComponent<SwitchScene> ().enabled = true;
		}
    }

    // Update is called once per frame
    void Update () {
		//if (username != null) {
			
		//}
	}

    public void inputName(string input)
    {
        username = input;
    }
}
