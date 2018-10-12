using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonRayCast : MonoBehaviour {
    Button parent;

    // Use this for initialization
    void Start()
    {
        parent = GetComponentInParent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickButton()
    {
        Debug.Log(parent.transform.name);
        parent.transform.parent.GetComponentInParent<UpgradeScript>().UpgradeItem(parent.transform.parent.name);
    }
}
