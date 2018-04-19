using UnityEngine;
using System.Collections;

public class Game2_block : MonoBehaviour {
    public int m_point = 1;
    public GameObject explosion;
    void Start () {
	}

	public float speed_down = (float)-2;

	// Update is called once per frame
	void Update () {
		Vector3 curpos = this.transform.position;
		curpos.y = curpos.y + speed_down * Time.deltaTime;
		this.transform.position = curpos;

	}

	void OnBecameInvisible()  
	{  
		if(this.transform.position.z>=0)Destroy(this.gameObject);  
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //碰到球，结束。
        if (other.tag.CompareTo("Player") == 0)
        {
            //Instantiate(explosion, other.transform.position, other.transform.rotation);
            Game1Manager.Instance.final();
        }

        //碰到下底面，即安全避过，加分+消失
        if (other.tag.CompareTo("wall") == 0)
        {
            Game1Manager.Instance.AddScore(m_point);
            Destroy(this.gameObject);
        }
    }
}
