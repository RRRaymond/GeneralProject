using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2_drawCircle : MonoBehaviour {

	private GameObject hero1;
	private GameObject hero2;
	private Vector3 centerPoint; 
	private float radiusLength;
	private LineRenderer m_LineRenderer;
	private float m_PerAngle; //每个相隔多少度
	// Use this for initialization
	void Start () {
		m_LineRenderer = GetComponent<LineRenderer>();
		m_PerAngle = (float)360.0 / 64;
		Vector2 circlePos = new Vector2 ();
		hero1 = GameObject.Find("two_star1");
		hero2 = GameObject.Find("two_star2");
		centerPoint = (hero1.transform.position + hero2.transform.position)/2;
		radiusLength = (hero2.transform.position.x - hero1.transform.position.x)/2;
		for (int i = 0; i < 64; i++) {
			circlePos.x = centerPoint.x + radiusLength * Mathf.Cos(m_PerAngle * i * Mathf.Deg2Rad);
			circlePos.y = centerPoint.y + radiusLength * Mathf.Sin(m_PerAngle * i * Mathf.Deg2Rad);
			m_LineRenderer.SetPosition(i,circlePos); //将计算出来的点赋值给LineRenderer
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
