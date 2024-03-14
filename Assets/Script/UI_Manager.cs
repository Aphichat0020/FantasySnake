using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject ui_start_game;
    public GameObject ui_Setting_game;
    public void Start_Game()
    {
       ui_start_game.SetActive(false);
       spawn_Entity.instance.spawnPlayer();
       spawn_Entity.instance.spawn_MyTeam_Entity();

    }
    public void Update()
    {
        Setting();
    }
    public void Setting()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ui_Setting_game.activeInHierarchy == false)
            {
                ui_Setting_game.SetActive(true);
                
            }
            else
            {
                ui_Setting_game.SetActive(false);
              
            }
        }
    }
    public void Exit_Game()
    {
        Application.Quit();
    }
}
