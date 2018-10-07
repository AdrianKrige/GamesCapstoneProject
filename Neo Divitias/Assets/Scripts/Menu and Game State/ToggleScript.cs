using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ToggleScript : MonoBehaviour {
    private UnityEngine.UI.Toggle toggle;
    Toggle[] ws;

    private void Start() { 
        toggle = GetComponent<UnityEngine.UI.Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        Refresh();
    }

    private void selectWeapon(int player, string w){
        if (player == 1){
            GameState.player_one.selectWeapon(string.Format("{0}_{1}", player, w));
        }
        else if (player == 2){
            GameState.player_two.selectWeapon(string.Format("{0}_{1}", player, w));
        }
    }

    private void deselectWeapon(int player, string w){
        if (player == 1){
            GameState.player_one.deselectWeapon(string.Format("{0}_{1}", player, w));
        }
        else if (player == 2){
            GameState.player_two.deselectWeapon(string.Format("{0}_{1}", player, w));
        }
    }

    public void makeDark()
    {
        UnityEngine.UI.ColorBlock cb = toggle.colors;
        cb.normalColor = Color.gray;
        cb.highlightedColor = Color.gray;

        toggle.colors = cb;
    }

    public void makeGreen()
    {
        UnityEngine.UI.ColorBlock cb = toggle.colors;

        cb.normalColor = Color.green;
        cb.highlightedColor = Color.green;

        toggle.colors = cb;
    }

    private void OnToggleValueChanged(bool isOn){
        if (transform.parent.name.Equals("Weapons"))
        {
            if (isOn)
            {
                if (gameObject.layer == 8)
                {
                    deselectWeapon(1, gameObject.GetComponent<Toggle>().ToString().ToLower());
                }
                else if (gameObject.layer == 9)
                {
                    deselectWeapon(2, gameObject.GetComponent<Toggle>().ToString().ToLower());
                }
                makeDark();
            }
            else
            {
                // Change the toggle to selected. This should then call refresh to deactivate the oldest weapon.
                if (gameObject.layer == 8)
                {
                    selectWeapon(1, gameObject.GetComponent<Toggle>().ToString().ToLower());
                }
                else if (gameObject.layer == 9)
                {
                    selectWeapon(2, gameObject.GetComponent<Toggle>().ToString().ToLower());
                }
                makeGreen();
            }
        }
        else
        {
            if (isOn)
            {
                if (gameObject.layer == 8)
                {
                    // Make another method for attributes(armour, dash, jump)
                }
                else if (gameObject.layer == 9)
                {
                    //
                }
                makeDark();
            }
            else
            {
                // Change the toggle to selected. This should then call refresh to deactivate the oldest weapon.
                if (gameObject.layer == 8)
                {
                }
                else if (gameObject.layer == 9)
                {
                }
                makeGreen();
            }
        }
        GameState.player_one.weaponDebug();
    }

    public void Refresh(){
        TextMeshProUGUI mText = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        TextMeshProUGUI cash_left = transform.parent.parent.GetComponentsInChildren<TextMeshProUGUI>()[7];
        Text cost = gameObject.GetComponentsInChildren<Text>()[0];
        Button upgrade = gameObject.GetComponentsInChildren<Button>()[0];

        string item_name = gameObject.name;
        int current_level = 0;
        int money = 0;
        bool upgradeable = false;
        bool affordable = false;

        if (gameObject.layer == 8){
            current_level = GameState.player_one.Equipment[item_name.ToLower()];
            money = GameState.player_one.money;
        }
        else if (gameObject.layer == 9){
            current_level = GameState.player_two.Equipment[item_name.ToLower()];
            money = GameState.player_two.money;
        }

        // Check if weapon is at max level or not
        int cost_of_upgrade = PlayerPrefs.GetInt(string.Format("{0}_{1}", item_name.ToLower(), current_level + 1));
        if (cost_of_upgrade != 0){
            upgradeable = true;
            if (cost_of_upgrade <= money){
                affordable = true;
            }
        }
        
        // Disable if max level and replace price with MAX
        if (upgradeable){
            cost.text = string.Format("{0}", PlayerPrefs.GetInt(string.Format("{0}_{1}", item_name.ToLower(), current_level + 1)));
        }
        else
        {
            cost.text = string.Format("MAX");
            upgrade.interactable = false;
            // Was a bug where if item became too expensive or max, it would become unclickable. However this would also mean you can select more things on controller.
            // In this case, just move the selection to the actual toggle
            toggle.Select();
        }
        
        // Can't click if cant afford
        if (!affordable){
            upgrade.interactable = false;
            toggle.Select();
        }


        if (current_level == 0)
        {
            //toggle.IsInteractable(false);
            toggle.interactable = false;
        }
        else
        {
            toggle.interactable = true;
        }

        mText.text = string.Format("{0}", current_level);
        cash_left.text = string.Format("$ {0}", GameState.player_one.money);
    }
}



