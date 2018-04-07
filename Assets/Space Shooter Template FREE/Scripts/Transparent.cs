using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparent : MonoBehaviour {
    public int score;
    public int myscore;
    public float interval;
    // Use this for initialization
    void Start () {
        Hide();
        score = int.Parse(GameObject.FindGameObjectWithTag("score").GetComponent<Text>().text);
        myscore = 0;
    }
	
    void Hide()
    {
        Color _color = GetComponent<SpriteRenderer>().color;
        _color.a = 0.0F;
        GetComponent<SpriteRenderer>().color = _color;
    }

    void Show()
    {
        Color _color = GetComponent<SpriteRenderer>().color;
        _color.a = 1.0F;
        GetComponent<SpriteRenderer>().color = _color;
    }

    IEnumerator Transp()
    {
        if(myscore < score)
        {
            myscore++;
            Show();
            yield return new WaitForSeconds(interval);
            Hide();
        }
    }
    // Update is called once per frame
    void Update () {
        score = int.Parse(GameObject.FindGameObjectWithTag("score").GetComponent<Text>().text);
        StartCoroutine(Transp());
    }
}
