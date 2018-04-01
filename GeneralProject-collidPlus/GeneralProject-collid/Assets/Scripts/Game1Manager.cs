using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//使用 该引用，才能获得 Text 组件。
using UnityEngine;

public class Game1Manager : MonoBehaviour {

    public static Game1Manager Instance;
    //得分
    public int m_score = 0;
    //记录
    public static int m_hiscore = 0;
    //游戏结束判断
    public bool flag = false;

    
    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //循环播放背景音乐
        //暂停游戏
        //if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Time.timeScale = 0;
        //}

        //分数
        GameObject.FindGameObjectWithTag("score").GetComponent<Text>().text = m_score.ToString();

        //游戏结束
        if (flag)
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("mscore").GetComponent<Text>().text = m_score.ToString();
            GameObject.FindGameObjectWithTag("hscore").GetComponent<Text>().text = m_hiscore.ToString();
            GameObject.Find("final").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.Find("final").GetComponent<CanvasGroup>().interactable = true;
            GameObject.Find("final").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

    }
    //void OnGuI()
    //{
    //    Debug.Log("ongui");
    //    //游戏暂停
    //    if (Time.timeScale == 0)
    //    {
    //        //继续游戏按钮
    //        if(GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "继续游戏"))
    //        {
    //            Time.timeScale = 1;
    //            Debug.Log("继续");
    //        }

    //        //退出游戏按钮
    //        if(GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "退出游戏"))
    //        {
    //            //退出游戏
    //            SceneManager.LoadScene("Main Scene");
    //        }
    //    }

    //    //显示当前得分
    //    GUI.skin.label.fontSize = 15;
    //    GUI.Label(new Rect(0, 25, Screen.width, 30), "得分" + m_score);

    //    if (flag)
    //    {
    //        Debug.Log("结束条件触发");
    //        //放大字体
    //        GUI.skin.label.fontSize = 50;

    //        //显示游戏失败
    //        GUI.skin.label.alignment = TextAnchor.LowerCenter;
    //        GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "游戏失败");

    //        GUI.skin.label.fontSize = 20;

    //        //显示按钮
    //        if(GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "再试一次"))
    //        {
    //            //读取当前关卡
    //            SceneManager.LoadScene("Game1");
    //        }
    //        if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "返回主页面"))
    //        {
    //            //返回主页面
    //            SceneManager.LoadScene("Main Scene");
    //        }

    //        GUI.skin.label.fontSize = 15;

    //        //显示最高分
    //        GUI.skin.label.alignment = TextAnchor.LowerCenter;
    //        GUI.Label(new Rect(0, 5, Screen.width, 30), "记录" + m_hiscore);

    //        //显示当前得分
    //        GUI.Label(new Rect(0, 25, Screen.width, 30), "得分" + m_score);

    //    }
    //}
    //增加分数
    public void AddScore( int point )
    {
        m_score += point;

        //更新高分记录
        if (m_hiscore < m_score)
            m_hiscore = m_score;
    }
}
