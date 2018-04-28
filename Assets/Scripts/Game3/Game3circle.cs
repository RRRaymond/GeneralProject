using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3circle : MonoBehaviour {


    public Game3Hero game3Hero;
    private float radius;
    private Vector3 center;
    private LineRenderer m_LineRenderer;
    private float m_PerAngle; //每个相隔多少度
    // Use this for initialization
    void Start () {
        m_LineRenderer = GetComponent<LineRenderer>();
		m_PerAngle = (float)360.0 / 64;
	}
	
	// Update is called once per frame
	void Update () {
        if (!game3Hero.isrotating)
        {
            m_LineRenderer.positionCount = 0;
            return;
        }
        if (game3Hero.minEnemy == null)
            return;
        if (center == game3Hero.minEnemy.transform.position && radius == game3Hero.mindistance)
            return;

        m_LineRenderer.positionCount = 64;
        center = game3Hero.minEnemy.transform.position;
        radius = game3Hero.mindistance;
        Vector2 circlePos = new Vector2();
        for (int i = 0; i < 64; i++)
        {
            circlePos.x = center.x + radius * Mathf.Cos(m_PerAngle * i * Mathf.Deg2Rad);
            circlePos.y = center.y + radius * Mathf.Sin(m_PerAngle * i * Mathf.Deg2Rad);
            m_LineRenderer.SetPosition(i, circlePos); //将计算出来的点赋值给LineRenderer
        }
    }
}
