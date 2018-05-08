using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3trail : MonoBehaviour {
    public Game3Hero game3Hero;
    public float width;
    public float time;
    private Color[] colors;
    private TrailRenderer tr;
    private int index = 0;
    private bool changeColor = false;
    // Use this for initialization
    void Start () {
        tr = GetComponent<TrailRenderer>();
        tr.startWidth = width;
        tr.endWidth = width;
        tr.time = time;
        colors = new Color[7];
        colors[0] = new Color(0.85f, 0.68f, 0.08f);
        colors[1] = new Color(0.98f, 0.83f, 0.01f);
        colors[2] = new Color(0.82f, 0.82f, 0.82f);
        colors[3] = new Color(0.23f, 0.76f, 0.33f);
        colors[4] = new Color(0.24f, 0.75f, 0.88f);
        colors[5] = new Color(0.28f, 0.38f, 0.90f);
        colors[6] = new Color(0.60f, 0.10f, 0.81f); 
        tr.startColor = colors[index];
        tr.endColor = colors[index];
    }
	
	// Update is called once per frame
	void Update () {
        if (game3Hero.isrotating && !changeColor)
        {
            nextColor();
            tr.startColor = colors[index];
            tr.endColor = colors[index];
            changeColor = true;
            return;
        }
        if (!game3Hero.isrotating)
        {
            changeColor = false;
        }
	}

    void nextColor()
    {
        if(index < colors.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
    }
}
