using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//使用 该引用，才能获得 Text 组件。

//要求添加MeshFilter和MeshRenderer组件
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Capacity : MonoBehaviour {

    private float hGame1;
    private float hGame2;
    private float hGame3;
    public int times;

    //设置顶点坐标的列表
    private List<Vector3> points = new List<Vector3>();


    // Use this for initialization
    void Start () {
        //if (Game1Manager.Instance == null || Game2Manager.Instance == null || Game3Manager.Instance == null)
        //    return;
        hGame1 = Game1Manager.m_hiscore;
        hGame2 = Game2Manager.m_hiscore;
        hGame3 = Game3Manager.m_hiscore;

        //hGame1 = 30;
        //hGame2 = 10;
        //hGame3 = 30;

        Vector3 game1 = new Vector3(0, hGame1 * times, 1);
        Vector3 game2 = new Vector3(-Mathf.Cos(Mathf.PI / 6) * hGame2 * times, -0.5f * hGame2 * times, 1);
        Vector3 game3 = new Vector3(Mathf.Cos(Mathf.PI / 6) * hGame3 * times, -0.5f * hGame3 * times, 1);

        points.Add(game1);
        points.Add(game2);
        points.Add(game3);
        MeshDrawTriangle();


        GameObject Game1 = GameObject.Find("hGame1");
        GameObject Game2 = GameObject.Find("hGame2");
        GameObject Game3 = GameObject.Find("hGame3");

        Game1.GetComponent<Text>().text = hGame1.ToString(); 
        Game2.GetComponent<Text>().text = hGame2.ToString();
        Game3.GetComponent<Text>().text = hGame3.ToString();
        //Game1.transform.position += game1;
        //Game2.transform.position += game2;
        //Game3.transform.position += game3;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void MeshDrawTriangle()
    {
        //新建一个Mesh
        Mesh triangleMesh = new Mesh();
        //把列表的顶点坐标赋给Mesh的vertexs
        triangleMesh.vertices = points.ToArray();
        //设置每个顶点颜色
        triangleMesh.colors = new Color[3] { Color.yellow, Color.red, Color.green};
        //设置三角形顶点数量
        int[] trianglePoints = new int[3];
        trianglePoints[0] = 0;
        trianglePoints[1] = 1;
        trianglePoints[2] = 2;
        //把三角形的数量给Mesh的三角形
        triangleMesh.triangles = trianglePoints;
        //设置三角形的相关参数
        triangleMesh.RecalculateBounds();
        triangleMesh.RecalculateNormals();
        triangleMesh.RecalculateTangents();
        //把三角形的Mesh赋给MeshFilter组件
        GetComponent<MeshFilter>().mesh = triangleMesh;
    }
}
