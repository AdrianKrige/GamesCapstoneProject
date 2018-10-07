using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour {
    string primary;
    string secondary;

    Toggle[] ws;

    List<Toggle> weapons = new List<Toggle>();


    // Use this for initialization
    void Start () {
        ws = gameObject.GetComponentsInChildren<Toggle>();

        if (gameObject.layer == 8)
        {
            primary = GameState.player_one.primary.Split('_')[1].Split(' ')[0];
            secondary = GameState.player_one.secondary.Split('_')[1].Split(' ')[0];
        }
        else if (gameObject.layer == 9)
        {
            primary = GameState.player_two.primary.Split('_')[1].Split(' ')[0];
            secondary = GameState.player_two.secondary.Split('_')[1].Split(' ')[0];
        }   
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.layer == 8)
        {
            primary = GameState.player_one.primary.Split('_')[1].Split(' ')[0];
            secondary = GameState.player_one.secondary.Split('_')[1].Split(' ')[0];
        }
        else if (gameObject.layer == 9)
        {
            primary = GameState.player_two.primary.Split('_')[1].Split(' ')[0];
            secondary = GameState.player_two.secondary.Split('_')[1].Split(' ')[0];
        }

        foreach (Toggle t in ws)
        {
            ToggleScript ts = t.GetComponent<ToggleScript>();

            if (!string.Equals(t.name.ToLower(),primary) && !string.Equals(t.name.ToLower(), secondary))
            {
                //Debug.Log("Dark " + t.name.ToLower() + " " + primary + " " + secondary);
                //Debug.Log("Green ");
                //Debug.Log(t.name.ToLower());
                //Debug.Log(primary);
                //Debug.Log(secondary);
                ts.makeDark();
                ts.autoOff();

                // (FIXED)The bug with having to double click is because we only change the colout here. WE do not deselect the toggle
            }
        }
    }
}
