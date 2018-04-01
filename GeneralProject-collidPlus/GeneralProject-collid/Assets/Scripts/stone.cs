using UnityEngine;
using System.Collections;

public class stone : MonoBehaviour {
    public int m_point = 1;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible()  
	{  
		if(this.transform.position.z>=0)Destroy(this.gameObject);  
	}  
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(this.transform.position.z >= 0)
        {
            if (other.tag.CompareTo("wall") == 0)
            {
                //左边陨石未被吸收
                if (this.transform.position.x < 0)
                {
                    //Destroy(GameObject.FindGameObjectWithTag("leftHero"));
                    Game1Manager.Instance.flag = true;
                }

            }
            if (other.tag.CompareTo("leftHero") == 0)
            {
                Game1Manager.Instance.AddScore(m_point);
                Destroy(this.gameObject);
            }
            if (other.tag.CompareTo("rightHero") == 0)
            {
                Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                Game1Manager.Instance.flag = true;

            }
        }
        
    }
}
