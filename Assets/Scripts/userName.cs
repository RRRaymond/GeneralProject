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
        if (username == null)
            GameObject.Find("namePanel").GetComponent<CanvasGroup>().alpha = 1;
        else
            GameObject.Find("namePanel").GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(username);
	}

    public void inputName(string input)
    {
        username = input;
    }
}
