﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ToggleScript : MonoBehaviour {
    private Toggle toggle;
    Toggle[] ws;
    public bool changedByCode;
    //ColorBlock cb;

    private void Start() {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        changedByCode = false;

        Refresh();
    }

    private void selectItem(int player, string w){
        w = w.Split(' ')[0];
        if (w.Equals("armour"))
        {

        }
        else if (w.Equals("jump") || w.Equals("dash"))
        {
            if (player == 1)
            {
                GameState.player_one.selectMovement(w);
            }
            else if (player == 2)
            { 
                GameState.player_two.selectMovement(w);
            }
        }
        else
        {
            if (player == 1)
            {
                GameState.player_one.selectWeapon(w);
            }
            else if (player == 2)
            {
                GameState.player_two.selectWeapon(w);
            }
        }
    }

    private void deselectItem(int player, string w){
        if (w.Equals("armour"))
        {

        }
        else if (w.Equals("jump") || w.Equals("dash"))
        {
            if (player == 1)
            {
                GameState.player_one.deselectMovement();
            }
            else if (player == 2)
            {
                GameState.player_two.deselectMovement();
            }
        }
        else
        {
            if (player == 1)
            {
                GameState.player_one.deselectWeapon(w);
            }
            else if (player == 2)
            {
                GameState.player_two.deselectWeapon(w);
            }
        }
    }


    private void OnToggleValueChanged(bool isOn){
        //Debug.Log(toggle.name + " " + isOn);
        if (!changedByCode)
        {
            Debug.Log("CHANGED MANUALLY " + toggle.name);
            if (!isOn) {
                Debug.Log("Deselect");
                if (gameObject.layer == 8)
                {
                    deselectItem(1, gameObject.GetComponent<Toggle>().name.ToLower());
                }
                else if (gameObject.layer == 9)
                {
                    deselectItem(2, gameObject.GetComponent<Toggle>().name.ToLower());
                }
            }
            else
            {
                Debug.Log("Select");
                // Change the toggle to selected. This should then call refresh to deactivate the oldest weapon.
                if (gameObject.layer == 8)
                {
                    selectItem(1, gameObject.GetComponent<Toggle>().name.ToLower());
                }
                else if (gameObject.layer == 9)
                {
                    selectItem(2, gameObject.GetComponent<Toggle>().name.ToLower());
                }
            }
        }
        else
        {
            Debug.Log("CHANGED BY CODE " + toggle.name);
        }

        Refresh();

        //debug blah
        if (gameObject.layer == 8)
        {
            GameState.player_one.playerDebug();
        }
        else if (gameObject.layer == 9)
        {
            GameState.player_two.playerDebug();
        }


    }

    public void Refresh() {
        string item_name = gameObject.name;
        int current_level = 0;

        int player = 1;
        if (gameObject.layer == 9)
        {
            player = 2;
        }

        if (player == 1){
            current_level = GameState.player_one.Equipment[item_name.ToLower()];
        }
        else if (player == 2){
            current_level = GameState.player_two.Equipment[item_name.ToLower()];
        }

        if (current_level == 0)
        {
            toggle.interactable = false;
        }
        else
        {
            toggle.interactable = true;
        }

        Toggle[] toggles = gameObject.transform.parent.GetComponentsInChildren<Toggle>();

        List<string> active = new List<string>();
        int armour;
        if (player == 1)
        {
            active.Add(GameState.player_one.primary);
            active.Add(GameState.player_one.secondary);
            active.Add(GameState.player_one.movement);
            armour = GameState.player_one.Equipment["armour"];
        }
        else
        {
            active.Add(GameState.player_two.primary);
            active.Add(GameState.player_two.secondary);
            active.Add(GameState.player_two.movement);
            armour = GameState.player_two.Equipment["armour"];
        }

        if (armour > 0)
        {
            active.Add("armour");
        }

        foreach (Toggle t in toggles)
        {
            {
                ColorBlock cb = t.colors;
                if (active.Contains(t.name.ToLower()))
                {
                    cb.normalColor = Color.green;
                    cb.highlightedColor = Color.red;
                }
                else
                {
                    cb.normalColor = Color.blue;
                    cb.highlightedColor = Color.red;
                    t.GetComponent<ToggleScript>().changedByCode = true;
                    t.isOn = false;
                    t.GetComponent<ToggleScript>().changedByCode = false;
                }
                t.colors = cb;
            }
        }


    }
}



