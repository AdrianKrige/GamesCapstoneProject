using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleScript : MonoBehaviour {

    private UnityEngine.UI.Toggle toggle;

    private void Start(){
        //tm = (TextMesh)transform.Find("Level").;
        //TextMeshPro mText = gameObject.GetComponent<TextMeshPro>();
        TextMeshProUGUI mText = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        string item_name = gameObject.name;
        //string player = gameObject.GetComponentInParent<e>();
        Debug.Log(item_name);
        int i = Game.current.GetItemLevel(item_name);
        Debug.Log("HI");
        mText.text = i.ToString();
        toggle = GetComponent<UnityEngine.UI.Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn){
        UnityEngine.UI.ColorBlock cb = toggle.colors;
        if (isOn){
            cb.normalColor = Color.gray;
            cb.highlightedColor = Color.gray;
        }
        else{
            cb.normalColor = Color.green;
            cb.highlightedColor = Color.green;
        }
        toggle.colors = cb;
    }
}



