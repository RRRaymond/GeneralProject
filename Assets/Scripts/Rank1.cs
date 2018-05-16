using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
		this.GetComponent<Image>().sprite = Resources.Load("xing1", typeof(Sprite)) as Sprite;
	}
	
	// Update is called once per frame
	void OnClick () {
		Debug.Log("正常调用了积分榜1事件");
		this.GetComponent<Image>().sprite = Resources.Load("xing2", typeof(Sprite)) as Sprite;
		GameObject obj1=GameObject.Find("Canvas/rankall");
		obj1.GetComponent<Image>().sprite = Resources.Load("zong1", typeof(Sprite)) as Sprite;

		GameObject obj2=GameObject.Find("Canvas/rank2");
		obj2.GetComponent<Image>().sprite = Resources.Load("ji1", typeof(Sprite)) as Sprite;

		GameObject obj3=GameObject.Find("Canvas/rank3");
		obj3.GetComponent<Image>().sprite = Resources.Load("liu1", typeof(Sprite)) as Sprite;

		string[] names = { "陈胖1", "采芒果的小胖胖", "游小小小小胖", "喵喵胖","陈钧涛陈胖2"};
		int[] scores = { 1024, 512, 256, 128, 64 };

		GameObject player1=GameObject.Find("Canvas/name1");
		player1.GetComponent<Text>().text = names[0];
		GameObject player2=GameObject.Find("Canvas/name2");
		player2.GetComponent<Text>().text = names[1];
		GameObject player3=GameObject.Find("Canvas/name3");
		player3.GetComponent<Text>().text = names[2];
		GameObject player4=GameObject.Find("Canvas/name4");
		player4.GetComponent<Text>().text = names[3];
		GameObject player5=GameObject.Find("Canvas/name5");
		player5.GetComponent<Text>().text = names[4];

		player1=GameObject.Find("Canvas/score1");
		player1.GetComponent<Text>().text = scores[0].ToString();
		player2=GameObject.Find("Canvas/score2");
		player2.GetComponent<Text>().text = scores[1].ToString();
		player3=GameObject.Find("Canvas/score3");
		player3.GetComponent<Text>().text = scores[2].ToString();
		player4=GameObject.Find("Canvas/score4");
		player4.GetComponent<Text>().text = scores[3].ToString();
		player5=GameObject.Find("Canvas/score5");
		player5.GetComponent<Text>().text = scores[4].ToString();
	}
}
