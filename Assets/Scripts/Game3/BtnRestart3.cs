using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnRestart3 : MonoBehaviour {

    //public AudioClip buttonClick;
    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        //AudioSource.PlayClipAtPoint(buttonClick, transform.localPosition);
        Time.timeScale = 1;
        SceneManager.LoadScene("Game3");
    }
}
