using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RankAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
		this.GetComponent<Image>().sprite = Resources.Load("zong2", typeof(Sprite)) as Sprite;
		string[] names = { "陈胖1", "陈钧涛陈胖2", "采芒果的小胖胖", "游小小小小胖", "喵喵胖" };
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
	
	private void OnClick()
	{
		Debug.Log("正常调用了总积分榜事件");
		this.GetComponent<Image>().sprite = Resources.Load("zong2", typeof(Sprite)) as Sprite;
		GameObject obj1=GameObject.Find("Canvas/rank1");
		obj1.GetComponent<Image>().sprite = Resources.Load("xing1", typeof(Sprite)) as Sprite;
		GameObject obj2=GameObject.Find("Canvas/rank2");
		obj2.GetComponent<Image>().sprite = Resources.Load("ji1", typeof(Sprite)) as Sprite;
		GameObject obj3=GameObject.Find("Canvas/rank3");
		obj3.GetComponent<Image>().sprite = Resources.Load("liu1", typeof(Sprite)) as Sprite;

		string[] names = { "陈胖1", "陈钧涛陈胖2", "采芒果的小胖胖", "游小小小小胖", "喵喵胖" };
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
