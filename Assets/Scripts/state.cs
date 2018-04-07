using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state : MonoBehaviour {

	private GameObject hero;
	private bool islocked = false;

	public enum herostate{
		left,right
	}

	private herostate channel;
	public herostate Channel{
		get{
			return channel;
		}
		set{
			channel =value;
			Debug.Log(channel);
		}
	}
	
	public void changeChannel(){
		if(islocked)
			return;
		islocked = true;
		if(Channel == herostate.right){
			//iTween.MoveTo(hero,hero.transform.position + new Vector3(-2, 0, 0), 1.5f);
			Channel = herostate.left;
			iTween.MoveTo(hero,iTween.Hash(
				"position", hero.transform.position + new Vector3(-2, 0,0),
				"time", 0.4f, 
				"easetype", iTween.EaseType.easeInBack,
				"oncomplete", "unlock"
				));
		}
		else{
			//iTween.MoveTo(hero,hero.transform.position + new Vector3(2, 0, 0), 1.5f);
			Channel = herostate.right;
			iTween.MoveTo(hero,iTween.Hash(
				"position", hero.transform.position + new Vector3(2, 0,0),
				"time", 0.4f, 
				"easetype", iTween.EaseType.easeInBack,
				"oncomplete", "unlock"
				));
		}
		
	}
	private void unlock(){
		islocked = false;
	}
	// Use this for initialization
	void Start () {
		if(this.transform.position.x > 0){
			channel = herostate.right;
			hero = GameObject.Find("rightHero");
		}
		else{
			channel = herostate.left;
			hero = GameObject.Find("leftHero");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
