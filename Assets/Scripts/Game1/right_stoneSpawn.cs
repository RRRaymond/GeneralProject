using UnityEngine;
using System.Collections;

public class right_stoneSpawn : MonoBehaviour {
	public Transform m_stone;
	protected Transform m_transform;
	int[] pos = { 1, 3};
    int cnt = 0;
    // Use this for initialization
    void Start () {
		m_transform = this.transform;
		StartCoroutine (SpawnStone ());
	}

	IEnumerator SpawnStone()
	{
        int maxstep = (int)100.0 / ((cnt / 10) + 1) + 200;
        float timestep = Random.Range(100, maxstep) / 100;
		yield return new WaitForSeconds (timestep);
		Debug.Log(m_transform.position);
		Vector3 new_postion = m_transform.position;

		int temp = Random.Range (1, 50);
		new_postion.x = pos [temp % 2];
		new_postion.y = 7;
		Object cloneObj = Instantiate (m_stone, new_postion, Quaternion.identity);
        cnt++;
        StartCoroutine(SpawnStone());
	}

	// Update is called once per frame
	void Update () {
	
	}
}
