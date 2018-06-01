using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Text;
using LitJson;

public class userName : MonoBehaviour {

    public static userName Instance;
    public static string username;
    public static int uid;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        // PlayerPrefs.DeleteAll();
        if(PlayerPrefs.HasKey("Username") && PlayerPrefs.HasKey("UID")){
            username = PlayerPrefs.GetString("Username");
            uid = PlayerPrefs.GetInt("UID");
            var request = (HttpWebRequest)WebRequest.Create("http://closecv.com:5000/api/user");
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("UID", uid.ToString(), "/", "closecv.com"));
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var resJson = JsonMapper.ToObject(responseString);
            if(((IDictionary)resJson).Contains("UID")){
                Game1Manager.m_hiscore = (int)resJson["score"]["Game1"];
                Game2Manager.m_hiscore = (int)resJson["score"]["Game2"];
                Game3Manager.m_hiscore = (int)resJson["score"]["Game3"];
            }
        }
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

    public void inputID(int input)
    {
        uid = input;
    }
}
