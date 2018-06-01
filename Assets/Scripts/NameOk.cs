using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Net;
using System.IO;
using System.Text;
using LitJson;

public class NameOk : MonoBehaviour {

	public GameObject go;

    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
		//go.GetComponent<SwitchScene> ().enabled = false;
		//Debug.Log (go);
    }

    private void OnClick()
    {
        InputField inputName = GameObject.Find("inputName").GetComponent<InputField>();
        if (inputName.text != "")
        {
            var request = (HttpWebRequest)WebRequest.Create("http://closecv.com:5000/api/user");
            
            var postData = "Username=" + inputName.text;
            var data = Encoding.UTF8.GetBytes(postData);
            
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.Timeout = 2000;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            
            var response = (HttpWebResponse)request.GetResponse();
            
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            
            var resJson = JsonMapper.ToObject(responseString);
            if(((IDictionary)resJson).Contains("msg")){

                GameObject.Find("namePanel").GetComponent<CanvasGroup>().alpha = 0;
                userName.Instance.inputName(resJson["content"]["Username"].ToString());
                userName.Instance.inputID((int)resJson["content"]["UID"]);
                PlayerPrefs.SetString("Username", userName.username);
                PlayerPrefs.SetInt("UID", userName.uid);
                go.GetComponent<SwitchScene> ().enabled = true;
            }
            

            
        }
    }
}
