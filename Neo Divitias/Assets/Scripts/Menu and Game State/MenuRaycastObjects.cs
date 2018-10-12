using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuRaycastObjects : MonoBehaviour {
    Toggle parent;
    ToggleScript ts;

    // Use this for initialization
    void Start() {
        parent = GetComponentInParent<Toggle>();
        ts = parent.GetComponent<ToggleScript>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void clickToggle()
    {
        Debug.Log(parent.name);
        if (parent.isOn)
        {
            Debug.Log("Make dark, turn off");
            ts.makeDark();
            ts.autoOff();
        }
        else
        {
            Debug.Log("Make green, turn on");
            ts.makeGreen();
            ts.autoOn();
        }
    }
}
