using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public GameObject ui_start_game;
    public GameObject ui_Setting_game;
    public GameObject ui_End_game;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
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
    public void UI_End_Game()
    {
        ui_End_game.SetActive(true);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene("FantasySnake");   
    }
    public void Exit_Game()
    {
        Application.Quit();
    }
}
