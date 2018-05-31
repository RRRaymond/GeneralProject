using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state : MonoBehaviour {

    public float speed = 2.5f;
	private GameObject hero;
	private bool islocked = false;
    public AudioClip click;

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
		}
	}
	
	public void changeChannel(){
		if(islocked)
			return;
		islocked = true;
        AudioSource.PlayClipAtPoint(click, GameObject.Find("MainCamera").transform.localPosition);
        if (Channel == herostate.right){
			//iTween.MoveTo(hero,hero.transform.position + new Vector3(-2, 0, 0), 1.5f);
			Channel = herostate.left;
			iTween.MoveTo(hero,iTween.Hash(
				"position", hero.transform.position + new Vector3(-2, 0,0),
				"time", 1/speed, 
				"easetype", iTween.EaseType.easeInQuad,
				"oncomplete", "unlock"
				));
		}
		else{
			//iTween.MoveTo(hero,hero.transform.position + new Vector3(2, 0, 0), 1.5f);
			Channel = herostate.right;
			iTween.MoveTo(hero,iTween.Hash(
				"position", hero.transform.position + new Vector3(2, 0,0),
				"time", 1/speed, 
				"easetype", iTween.EaseType.easeInQuad,
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
