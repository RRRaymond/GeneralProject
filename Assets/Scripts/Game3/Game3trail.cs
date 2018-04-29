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
        colors[0] = new Color(1, 0.27f, 0);
        colors[1] = new Color(1, 0.55f, 0);
        colors[2] = new Color(1, 0.90f, 0);
        colors[3] = new Color(0.55f, 1, 0);
        colors[4] = new Color(0, 0.90f, 0.97f);
        colors[5] = new Color(0.11f, 0.56f, 1);
        colors[6] = new Color(0.54f, 0.17f, 0.88f);
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
