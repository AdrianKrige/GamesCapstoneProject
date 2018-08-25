using UnityEngine;
using System.Collections;
 
[System.Serializable]
public class Player{
    public string name;
    public int pistol = 1;
    public int shotgun = 0;
    public int smg = 0;
    public int rifle = 0;
    public int armour = 2;
    public int accuracy = 0;
    public int dash = 0;
    public int jump = 3;

    public Player(string name){
        this.name = name;
    }
}