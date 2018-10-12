﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void NewGame(){
        GameState.game_level = 1;
        GameState.player_one = new Player("1");
        GameState.player_two = new Player("2");
        GameState.SetPrefs();

        LoadShop();
    }

    public void StartNextLevel(){
        GameState.SetPrefs();
        SceneManager.LoadScene(string.Format("Cutscene {0}", GameState.game_level));
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadShop(){
        // This should ideally be somewhere that only gets called once on setup.
        GameState.BaseSetup();
        try
        {
            GameState.GetPrefs();
        }
        catch (System.Exception e)
        {
            // TODO. Make this a GUI pop up or something. Give the user feedback. 
            // Another option would be to only show the continue if prefs can be set.
            Debug.LogError("Prefs couldnt be loaded beacuase they havent been set yet.");
        }
        GameState.GetPrefs();
        SceneManager.LoadScene("Shop");
    }
    
    // This will be done by Matt
    public void FinishLevel(){
        // This is hacky shit that manually sets the money after each level. THIS MUST BE CHANGED.
        if(GameState.game_level == 1)
        {
            GameState.player_one.money += 110;
            GameState.player_two.money += 110;
        }
        else if (GameState.game_level == 2)
        {
            GameState.player_one.money += 320;
            GameState.player_two.money += 380;
        }
        else if (GameState.game_level == 3)
        {
            GameState.player_one.money += 380;
            GameState.player_two.money += 380;
        }
        GameState.game_level++;
        GameState.SetPrefs();
        LoadShop();
    }

    public void QuitGame(){
        GameState.SetPrefs();
        Debug.Log("Quitting!");
        Application.Quit();
    }

    public void ReturnToMain(){
        // This is a bit hacky but it allows us to go back to main menu from settings and controls before a game has been started.
        // Maybe fix if we have extra time at the end
        try {
            GameState.SetPrefs();
        }
        catch(System.Exception e){
            Debug.LogError("Prefs couldnt be set because GameState hasnt been instantiated.");
        }
        SceneManager.LoadScene("Main");
    }
}
