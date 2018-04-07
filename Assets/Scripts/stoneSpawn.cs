using UnityEngine;
using System.Collections;

public class stoneSpawn : MonoBehaviour {
	public Transform m_stone;
	protected Transform m_transform;
	int[] pos = {-3, -1, 1, 3};

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		StartCoroutine (SpawnStone ());
	}

	IEnumerator SpawnStone()
	{
		float timestep = Random.Range (100, 200) / 100;
		yield return new WaitForSeconds (timestep);
		Debug.Log(m_transform.position);
		Vector3 new_postion = m_transform.position;

		int temp = Random.Range (1, 50);
		new_postion.x = pos [temp % 4];
		new_postion.y = 7;
		Object cloneObj = Instantiate (m_stone, new_postion, Quaternion.identity);

		StartCoroutine (SpawnStone());
	}

	// Update is called once per frame
	void Update () {
	
	}
}
