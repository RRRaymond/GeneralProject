
using UnityEngine;
using System.Collections;

public class Game2_blockSpawn : MonoBehaviour {
	public Transform m_block_long;
	public Transform m_block_short;
	public Transform m_block_square;
	protected Transform m_transform;

	int cnt = 0;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		StartCoroutine (SpawnBlock ());
	}

	IEnumerator SpawnBlock()
	{
		double maxstep0 = (100.0 / ((cnt / 10) + 1) + 300);
		int maxstep = (int)(maxstep0);
		float timestep = Random.Range(200, maxstep) / 100;
		yield return new WaitForSeconds (timestep);

		Vector3 new_postion = m_transform.position;

		int temp = Random.Range (1, 10000);
		new_postion.x = (float)(temp % 800 - 400)/(float)100.0;
		new_postion.y = 8;

		int temp2 = Random.Range (1, 15);
		Transform temp_t;
		if (temp2 % 3 == 0)
			temp_t = m_block_long;
		else if(temp2 % 3 == 1)
			temp_t = m_block_short;
		else
			temp_t = m_block_square;
		Object cloneObj = Instantiate (temp_t, new_postion, Quaternion.identity);
		cnt++;
		StartCoroutine (SpawnBlock());
	}

	// Update is called once per frame
	void Update () {

	}
}
