using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3generator : MonoBehaviour {

	public Transform m_stone1;
	public Transform m_stone2;
	public Transform m_stone3;
    public GameObject light;

    protected Transform m_transform;

	public int interval_ms = 100;
	public int interval_offset = 100;
	public int speed_persec = 2;

	int cnt = 0;
	float cur_y = 0;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		StartCoroutine (SpawnStone ());
	}

	IEnumerator SpawnStone()
	{
		double maxstep0 = (interval_offset / ((cnt / 15) + 1) + interval_ms);
		int maxstep = (int)(maxstep0);
        float timestep = Random.Range(interval_ms, maxstep) / 100.0f;
		yield return new WaitForSeconds (timestep);

		Vector3 new_postion = m_transform.position;
		int temp = Random.Range (-280, 280);
		new_postion.x = temp/100.0f;
		cur_y = cur_y + timestep;
		new_postion.y = speed_persec * cur_y + 9;


		Object m_stone;
		int temp1 = Random.Range (0, 100);
		if (temp1 % 3 == 0)
			m_stone = m_stone1;
		else if (temp1 % 3 == 1)
			m_stone = m_stone2;
		else
			m_stone = m_stone3;
		
		Object cloneObj = Instantiate (m_stone, new_postion, Quaternion.identity);
        Object effect = Instantiate(light, new_postion, Quaternion.identity);
        cnt++;
		StartCoroutine (SpawnStone());
	}

	// Update is called once per frame
	void Update () {

	}
}
