using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2_player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //碰到球，结束。
        if (other.tag.CompareTo("Player") == 0)
        {
            Game1Manager.Instance.final();
        }

        //碰到下底面，即安全避过，加分+消失
        if (other.tag.CompareTo("wall") == 0)
        {
            //Game1Manager.Instance.AddScore(m_point);
            Destroy(this.gameObject);
        }
    }
}
