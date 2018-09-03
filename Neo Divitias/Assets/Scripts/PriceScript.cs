using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    private void Start()
    {
        Text mText = gameObject.GetComponentsInChildren<Text>()[0];
        string item_name = gameObject.name;

        mText.text = string.Format("{0}", PlayerPrefs.GetInt("pistol_3"));
    }
}
