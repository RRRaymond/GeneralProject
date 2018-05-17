using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//使用 该引用，才能获得 Text 组件。
using UnityEngine;

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

        //更新高分记录
        if (m_hiscore < m_score)
            m_hiscore = m_score;
    }

    public int HightScore()
    {
        return m_hiscore;
    }
}
