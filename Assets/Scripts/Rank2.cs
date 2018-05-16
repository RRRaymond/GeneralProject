using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
		this.GetComponent<Image>().sprite = Resources.Load("ji1", typeof(Sprite)) as Sprite;
	}
	
	// Update is called once per frame
	void OnClick () {
		Debug.Log("正常调用了积分榜2事件");
		this.GetComponent<Image>().sprite = Resources.Load("ji2", typeof(Sprite)) as Sprite;
		GameObject obj1=GameObject.Find("Canvas/rankall");
		obj1.GetComponent<Image>().sprite = Resources.Load("zong1", typeof(Sprite)) as Sprite;
		GameObject obj2=GameObject.Find("Canvas/rank1");
		obj2.GetComponent<Image>().sprite = Resources.Load("xing1", typeof(Sprite)) as Sprite;
		GameObject obj3=GameObject.Find("Canvas/rank3");
		obj3.GetComponent<Image>().sprite = Resources.Load("liu1", typeof(Sprite)) as Sprite;
	}
}
