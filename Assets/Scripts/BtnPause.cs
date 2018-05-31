using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BtnPause : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        Time.timeScale = 0;
        GameObject.Find("pause").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.Find("pause").GetComponent<CanvasGroup>().interactable = true;
        GameObject.Find("pause").GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
