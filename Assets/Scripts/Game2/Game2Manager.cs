using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//使用 该引用，才能获得 Text 组件。
using UnityEngine;
using System.Net;
using System.IO;
using System.Text;
using LitJson;
public class Game2Manager : MonoBehaviour {

    public static Game2Manager Instance;
    //得分
    public int m_score = 0;
    //记录
    public static int m_hiscore = 0;
    //游戏结束判断
    //public bool flag = false;


    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //循环播放背景音乐
        //暂停游戏
        //if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Time.timeScale = 0;
        //}

        //分数
        GameObject.FindGameObjectWithTag("score").GetComponent<Text>().text = m_score.ToString();

    }
    public void final()
    {
        Time.timeScale = 0;
        if (m_hiscore < m_score){

            m_hiscore = m_score;

            var request = (HttpWebRequest)WebRequest.Create("http://closecv.com:5000/api/score");
            
            var postData = "Game=2" + "&Score=" + m_hiscore.ToString();
            var data = Encoding.UTF8.GetBytes(postData);
            
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("UID", userName.uid.ToString(), "/", "closecv.com"));
            request.Timeout = 2000;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            
            var response = (HttpWebResponse)request.GetResponse();
        }
        GameObject.FindGameObjectWithTag("mscore").GetComponent<Text>().text = m_score.ToString();
        GameObject.FindGameObjectWithTag("hscore").GetComponent<Text>().text = m_hiscore.ToString();
        GameObject.Find("final").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.Find("final").GetComponent<CanvasGroup>().interactable = true;
        GameObject.Find("final").GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    //增加分数
    public void AddScore(int point)
    {
        m_score += point;

        // //更新高分记录
        // if (m_hiscore < m_score)
        //     m_hiscore = m_score;
    }

    public int HightScore()
    {
        return m_hiscore;
    }
}
