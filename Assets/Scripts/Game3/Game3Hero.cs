﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3Hero : MonoBehaviour {

	public float speed = 1;
	public GameObject minEnemy;
	public float mindistance;
	public float direction = Mathf.PI/2f;
	public bool isrotating = false;
	public Game3touch game3Touch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float hight = this.transform.position.y;
        float x = this.transform.position.x;
        if (Game3Manager.Instance.m_score < hight)
            Game3Manager.Instance.ChangeScore(hight);
        if (game3Touch.checktouch())
        {
            if (isrotating)
            {
                circularMotion();
                return;
            }
            checkEnemy();
            if (mindistance == 100000000000)
                return;
            if (checkDistance())
            {
                Vector3 tempPosition = this.transform.position;
                Vector3 center = minEnemy.transform.position;
                tempAngle = Mathf.Atan2(tempPosition.y - center.y, tempPosition.x - center.x);
                var flag = (tempAngle + Mathf.PI / 2 - direction) % (2 * Mathf.PI);
                Vector3 radialVector = tempPosition - center;
                Vector3 tangentialVector = new Vector3(radialVector.y, -radialVector.x, 0);
                Vector3 directionVector = new Vector3(Mathf.Cos(direction), Mathf.Sin(direction), 0);
                if (Vector3.Dot(tangentialVector, directionVector) > 0)
                {
                    clockwise = -1;
                }
                else
                {
                    clockwise = 1;
                }
                circularMotion();
                return;
            }
        }
        else if (x > 3.8 || x < -3.8)
            Game3Manager.Instance.final();
		isrotating = false;
		linearMotion();

	}

	//find nearest enemy
	void checkEnemy(){
		var enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies == null)
            return;
		mindistance = 100000000000;
		foreach(GameObject enemy in enemies){
			float distance = (this.transform.position - enemy.transform.position).magnitude;
			if(distance<mindistance){
				mindistance = distance;
				minEnemy = enemy;
			}
		}
	}

	void linearMotion(){
		Vector3 tempPosition = new Vector3();
		tempPosition.x = this.transform.position.x + Mathf.Cos(direction) * speed * Time.deltaTime;
		tempPosition.y = this.transform.position.y + Mathf.Sin(direction) * speed * Time.deltaTime; 
		tempPosition.z = 0;
		this.transform.position = tempPosition;
	}

	float tempAngle;
	int clockwise;
	void circularMotion(){
		isrotating = true;
		Vector3 tempPosition = this.transform.position;
		Vector3 center = minEnemy.transform.position;
		float angleSpeed = speed / mindistance;
		Vector3 newPos = new Vector3();
		tempAngle += angleSpeed*clockwise*Time.deltaTime;
		newPos.x = center.x + Mathf.Cos(tempAngle)*mindistance;
		newPos.y = center.y + Mathf.Sin(tempAngle)*mindistance;
		newPos.z = 0;
		this.transform.position = newPos;
		direction += angleSpeed*clockwise*Time.deltaTime;
		if(direction>Mathf.PI)
			direction-=2*Mathf.PI;
		else if(direction<-Mathf.PI)
			direction+=2*Mathf.PI;
	}

	bool checkDistance(){
		Vector3 vec1 = new Vector3(Mathf.Cos(direction), Mathf.Sin(direction), 0);
		Vector3 vec2 = this.transform.position - minEnemy.transform.position;
		float flag = Vector3.Dot(vec1, vec2);
		if(flag>0.01){
			float dotresult = Vector3.Dot(vec1, new Vector3(vec2.y, -vec2.x, 0));
			if(dotresult>0.01){
				direction = Mathf.Atan2(-vec2.x, vec2.y);
			}else{
				direction = Mathf.Atan2(vec2.x, -vec2.y);
			}
			isrotating = true;
			return true;
		}else{

		}
		return false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("碰撞产生，collid happened!!!");
        //碰到球，结束。
        if (other.tag.CompareTo("enemy") == 0)
        {
            Debug.Log("碰到球了，collid happened!!!");
            Game3Manager.Instance.final();
        }
        
    }
}
