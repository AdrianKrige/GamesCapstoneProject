using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game{
    public static Game current;
    public string name;
    public Player player_one;
    public Player player_two;
    public int next_level;

    public Game(string name){
        this.name = name;
        player_one = new Player("Player One");
        player_two = new Player("Player Two");
        next_level = 1;
    }

    public void IncrLevel(){
        next_level++;
    }
       
    // Make this method take in a player as a parameter.
    public int GetItemLevel(string item){
        Player p = player_one;
        Debug.Log("HELLO");
        Debug.Log(item);
        int r = (int)p.GetType().GetProperty(item.ToLower()).GetValue(p, null);
        Debug.Log(r);
        return r;
    }
}