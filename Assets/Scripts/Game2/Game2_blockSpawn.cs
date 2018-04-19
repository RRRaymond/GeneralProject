
using UnityEngine;
using System.Collections;

public class Game2_blockSpawn : MonoBehaviour {
	public Transform m_block_long;
	public Transform m_block_short;
	public Transform m_block_square;
	protected Transform m_transform;

	//parameters
	public int interval_ms = 300;
	public int interval_range = 200;
	public float interval_long_short = 1.0f;
	public float interval_long_long = 2.0f;


	int cnt = 0;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		StartCoroutine (SpawnBlock ());
	}

	IEnumerator SpawnBlock()
	{
		double maxstep0 = (interval_range / ((cnt / 10) + 1.0) + interval_ms);
		int maxstep = (int)(maxstep0);
		float timestep = Random.Range(300, maxstep) / 100;
		yield return new WaitForSeconds (timestep);

		Vector3 new_postion = m_transform.position;

		int temp = Random.Range (1, 10000);
		new_postion.x = (float)(temp % 600 - 200)/(float)100.0;
		new_postion.y = 8;

		int types = 5;
		int temp2 = Random.Range (1, 15);
		if (temp2 % types == 0) {
			Transform temp_t = m_block_long;
			Object cloneObj = Instantiate (temp_t, new_postion, Quaternion.identity);
		} else if (temp2 % types == 1) {
			Transform temp_t = m_block_short;
			Object cloneObj = Instantiate (temp_t, new_postion, Quaternion.identity);
		} else if (temp2 % types == 2) {
			Transform temp_t = m_block_square;
			Object cloneObj = Instantiate (temp_t, new_postion, Quaternion.identity);
		} else if (temp2 % types == 3) {
			Transform temp_t1 = m_block_long;
			Transform temp_t2 = m_block_short;
			int temp3 = Random.Range (1, 15);
			Random.Range (1, 15);
			Vector3 pos1 = m_transform.position;
			Vector3 pos2 = m_transform.position;
			pos1.x = -2;
			pos1.y = 8;
			if (temp3 % 2 == 0) {
				pos2.x = 2.5f;
				pos2.y = 8;
				Object cloneObj1 = Instantiate (temp_t1, pos1, Quaternion.identity);
				yield return new WaitForSeconds (interval_long_short);
				Object cloneObj2 = Instantiate (temp_t2, pos2, Quaternion.identity);
			} else {
				pos2.x = 2;
				pos2.y = 8;
				Object cloneObj1 = Instantiate (temp_t1, pos2, Quaternion.identity);
				yield return new WaitForSeconds (interval_long_short);
				Object cloneObj2 = Instantiate (temp_t2, pos1, Quaternion.identity);
			}
		} else if (temp2 % types == 4) {
			int temp3 = Random.Range (1, 4);
			int temp4 = Random.Range (1, 15);
			Vector3 pos1 = m_transform.position;
			pos1.y = 8;
			if (temp4 % 2 == 0)
				pos1.x = -2;
			else
				pos1.x = 1;
			Transform temp_t1 = m_block_long;
			Object cloneObj1 = Instantiate (temp_t1, pos1, Quaternion.identity);
			while (temp3--!=0) {
				yield return new WaitForSeconds (interval_long_long);
				Object cloneObj = Instantiate (temp_t1, pos1, Quaternion.identity);
			}

		}


		cnt++;
		StartCoroutine (SpawnBlock());
	}

	// Update is called once per frame
	void Update () {

	}
}
