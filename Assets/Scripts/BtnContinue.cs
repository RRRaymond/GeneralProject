using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnContinue : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameObject.Find("pause").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("pause").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("pause").GetComponent<CanvasGroup>().blocksRaycasts = false;
        Time.timeScale = 1;
    }
}
