using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2_HeroMove : MonoBehaviour {
	private GameObject hero1;
	private GameObject hero2;
	private Vector3 centerPoint; 
	private float radiusLength;
	private bool direction;
	private float tempAngle;
	private bool istouched;
    public float speed = 1;
    public AudioClip click;
	// Use this for initialization
	void Start () {
		direction = false;
		tempAngle = 0;
		hero1 = GameObject.Find("two_star1");
		hero2 = GameObject.Find("two_star2");
		centerPoint = (hero1.transform.position + hero2.transform.position)/2;
		radiusLength = (hero2.transform.position.x - hero1.transform.position.x)/2;
	}
	
	// Update is called once per frame
	void Update () {
		//MobilePick();
		MousePick();
		if(!istouched)
			return;
		rotate(direction, Time.deltaTime);
	}
	
	void rotate (bool direction, float deltaTime){
		Vector3 tempPosition = new Vector3();
		int direct = direction?-1:1;
		tempAngle = direct * deltaTime * speed + tempAngle;
		tempPosition.x = centerPoint.x + Mathf.Cos(tempAngle) * radiusLength;
		tempPosition.y = centerPoint.y + Mathf.Sin(tempAngle) * radiusLength;
		tempPosition.z = 0;
		hero2.transform.position = tempPosition;
		hero1.transform.position = 2 * centerPoint - tempPosition;
	}

	void MobilePick()  {  
		if (Input.touchCount != 1 )  
			return;
        
        if (Input.GetTouch(0).phase == TouchPhase.Began)  
		{
            if (!istouched)
                AudioSource.PlayClipAtPoint(click, GameObject.Find("MainCamera").transform.localPosition);
            RaycastHit hit;  
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);  
	
			if (Physics.Raycast(ray, out hit))  
			{   
				istouched = true;
				direction = hit.transform.name=="right_collider"?true:false;
				//funct(hit.transform.name);
			}  
		}  
		else if(Input.GetTouch(0).phase == TouchPhase.Ended){
			istouched = false;
		}
	} 
	void MousePick()  {
        
        if (Input.GetMouseButtonDown(0))  
		{
            if(!istouched)
                AudioSource.PlayClipAtPoint(click, GameObject.Find("MainCamera").transform.localPosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
			RaycastHit hit;  
	
			if (Physics.Raycast(ray, out hit))  
			{  
				istouched = true;
				direction = hit.transform.name=="right_collider"?true:false;
				//funct(hit.transform.name);
			}  
		}  
		else if (Input.GetMouseButtonUp(0)){
			istouched = false;
		}
	}  
}
