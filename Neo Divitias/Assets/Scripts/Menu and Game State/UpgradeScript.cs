﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeScript : MonoBehaviour {
    private UnityEngine.UI.Toggle toggle;

    public void UpgradeItem(string item){
        toggle = GameObject.FindGameObjectWithTag(item.ToLower()).GetComponent<UnityEngine.UI.Toggle>();

        int current_level;
        int cost_of_upgrade;

        // Dont need to check if player can afford item because items that are too expensive wont be interactable
        // Wasn't sure how to best differentiate between player 1 and player 2 here. So put them in different layers
        // Also couldnt find a wayto get gameobject layer by naem, so have to use integer values
        if (gameObject.layer == 8){
            current_level = GameState.player_one.Equipment[item.ToLower()];
            cost_of_upgrade = PlayerPrefs.GetInt(string.Format("{0}_{1}", item.ToLower(), current_level + 1));
            GameState.player_one.Equipment[item.ToLower()]++;
            GameState.player_one.money -= cost_of_upgrade;
            //Debug.Log(GameState.player_one.money);
        }
        else if (gameObject.layer == 9){
            current_level = GameState.player_two.Equipment[item.ToLower()];
            cost_of_upgrade = PlayerPrefs.GetInt(string.Format("{0}_{1}", item.ToLower(), current_level + 1));
            GameState.player_two.Equipment[item.ToLower()]++;
            GameState.player_two.money -= cost_of_upgrade;
        }
        toggle.Select();
        //Debug.Log(toggle.name);
        
        foreach (UnityEngine.UI.Toggle t in gameObject.GetComponentsInChildren <UnityEngine.UI.Toggle>())
        {
            ToggleScript ts = t.GetComponent<ToggleScript>();
            // Call refresh here to deactivate items that the player cant afford now
            ts.Refresh();
        }
    }
}
