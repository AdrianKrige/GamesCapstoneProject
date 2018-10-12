using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class MenuRaycast : MonoBehaviour {
    public Camera playerCam;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        // GraphicRaycaster hit;
        if (Input.GetButtonDown("Jump p1") || Input.GetButtonDown("Jump p2")) { 
            if (Physics.Raycast(rayOrigin, playerCam.transform.forward, out hit, 1000000))
            {
                GameObject target = hit.collider.gameObject;
                if (target != null)
                {
                    Debug.Log("Yeah boi");
                    MenuRaycastObjects b = target.GetComponent<MenuRaycastObjects>();
                    ButtonRayCast c = target.GetComponent<ButtonRayCast>();
                    try
                    {
                        Debug.Log("B");
                        b.clickToggle();
                    }catch
                    {
                        Debug.Log("C");
                        c.clickButton();
                    }
                }
            }
            else
            {
                // spawn particle effect at end of range
            }
        }
    }

}
