using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NameOk : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        InputField inputName = GameObject.Find("inputName").GetComponent<InputField>();
        if (inputName.text != "")
        {
            GameObject.Find("namePanel").GetComponent<CanvasGroup>().alpha = 0;
            userName.Instance.inputName(inputName.text);
        }
    }
}
