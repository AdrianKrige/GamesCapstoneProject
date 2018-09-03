using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ToggleScript : MonoBehaviour {

    private UnityEngine.UI.Toggle toggle;

    private void Start(){
        TextMeshProUGUI mText = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        Text cost = gameObject.GetComponentsInChildren<Text>()[0];

        string item_name = gameObject.name;

        if (gameObject.layer == 8){
            int current_level = GameState.player_one.Equipment[item_name.ToLower()];
            mText.text = string.Format("{0}", current_level);
            cost.text = string.Format("$ {0}", PlayerPrefs.GetInt(string.Format("{0}_{1}", item_name.ToLower(), current_level + 1)));
        }

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



