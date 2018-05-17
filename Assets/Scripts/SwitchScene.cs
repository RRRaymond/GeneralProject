using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		//点击事件检测，鼠标或触碰
		MousePick();
		//MobilePick();
	}

	public void funct(string name){
		switch(name){
			case "star1":
				SceneManager.LoadScene("Game1");
				break;
			case "star2":
				SceneManager.LoadScene("Game2");
				break;
			case "star3":
				SceneManager.LoadScene("Game3");
				break;
			case "return":
                GameObject.Find("pause").GetComponent<CanvasGroup>().alpha = 1;
                GameObject.Find("pause").GetComponent<CanvasGroup>().interactable = true;
                GameObject.Find("pause").GetComponent<CanvasGroup>().blocksRaycasts = true;
                Time.timeScale = 0;
				break;
            case "capacity":
                SceneManager.LoadScene("Capacity");
                break;
			case "left_collider":
				moveHeroes("leftHero");
				break;
			case "right_collider":
				moveHeroes("rightHero");
				break;
			default:
				break;
		}
	}

	void moveHeroes(string name){
		var hero = GameObject.Find(name);
		if(hero != null){
			var mystate = hero.GetComponent<state>();
			mystate.changeChannel();
			//iTween.MoveTo(hero, new Vector3(0, 0, 0), 3);
		}
		
	}

	void MobilePick()  {  
		if (Input.touchCount != 1 )  
			return;  
	
		if (Input.GetTouch(0).phase == TouchPhase.Began)  
		{  
			RaycastHit hit;  
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);  
	
			if (Physics.Raycast(ray, out hit))  
			{   
				funct(hit.transform.name);
			}  
		}  
	} 
	void MousePick()  {  
		if(Input.GetMouseButtonUp(0))  
		{  
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
			RaycastHit hit;  
	
			if (Physics.Raycast(ray, out hit))  
			{  
				funct(hit.transform.name);
			}  
		}  
	}  
}
