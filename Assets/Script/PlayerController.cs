using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Current_Positon current_Direction_player;
    public List<GameObject> List_Team_Player_Spawn = new List<GameObject>();
    public int Team_Player_Speed = 10;

    public List<GameObject> Team_Players = new List<GameObject>();
    public List<Current_Positon> Move_History = new List<Current_Positon>();
    public List<Vector3> positon_History_Team_Players = new List<Vector3>();

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

    public enum Current_Positon{
        Up,
        Left,
        Right,
        Down
    }
    public void Start()
    {
        positon_History_Team_Players.Insert(0, transform.position);
        Move_History.Insert(0, current_Direction_player);
        AddTeam_Start();

    }
    void Update()
    {
        Controller_Player();
      
        
         int i = 0;
        
        foreach (GameObject Team_Player in Team_Players)
        {
           
            Vector3 pos = positon_History_Team_Players[Mathf.Min(i , positon_History_Team_Players.Count-1)];
            Vector3 posforward = pos - Team_Player.transform.position;
            Team_Player.transform.position += posforward* Team_Player_Speed* Time.deltaTime;

            Current_Positon dir = Move_History[Mathf.Min(i,Move_History.Count - 1)];

            MoveHistory(dir, Team_Player);
            i++;
        }
        Chang_MyTeam();
    }
    public void Controller_Player()
    {
        
        switch (current_Direction_player)
        {
            case Current_Positon.Up:

                if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    
                    current_Direction_player = Current_Positon.Up;
                    transform.position = transform.position + new Vector3(0, 0, 1);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();

                }
                if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    current_Direction_player = Current_Positon.Left;
                    transform.position = transform.position + new Vector3(-1, 0, 0);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
                if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    current_Direction_player = Current_Positon.Right;
                    transform.position = transform.position + new Vector3(1, 0, 0);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
             

                break;
            case Current_Positon.Left:
                if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    current_Direction_player = Current_Positon.Left;
                    transform.position = transform.position + new Vector3(-1, 0, 0);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
                if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    current_Direction_player = Current_Positon.Up;
                    transform.position = transform.position + new Vector3(0, 0, 1);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
                if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
                {
                    current_Direction_player = Current_Positon.Down;
                    transform.position = transform.position + new Vector3(0, 0, -1);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }

               
                break;
            case Current_Positon.Right:
                if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    current_Direction_player = Current_Positon.Right;
                    transform.position = transform.position + new Vector3(1, 0, 0);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
                if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    current_Direction_player = Current_Positon.Up;
                    transform.position = transform.position + new Vector3(0, 0, 1);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
                if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
                {
                    current_Direction_player = Current_Positon.Down;
                    transform.position = transform.position + new Vector3(0, 0, -1);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
               
                break;
            case Current_Positon.Down:
                if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
                {
                    current_Direction_player = Current_Positon.Down;
                    transform.position = transform.position + new Vector3(0, 0, -1);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
                if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    current_Direction_player = Current_Positon.Left;
                    transform.position = transform.position + new Vector3(-1, 0, 0);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
                if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    current_Direction_player = Current_Positon.Right;
                    transform.position = transform.position + new Vector3(1, 0, 0);
                    positon_History();
                    MoveHistory(current_Direction_player, Team_Players[0]);
                    Move_History.Insert(0, current_Direction_player);
                    Delete_History();
                }
                break;
        }
    }
    public void Action_Hit_Player()
    {
        Move_History.RemoveAt(0);
        positon_History_Team_Players.RemoveAt(0);
        transform.position = positon_History_Team_Players[0];
        current_Direction_player = Move_History[0];

    }
    public void AddTeam_Start()
    {
        int i = 0;
          Vector3 pos = positon_History_Team_Players[Mathf.Max(i, positon_History_Team_Players.Count-1)];
          GameObject team = Instantiate(List_Team_Player_Spawn[0], pos, Quaternion.identity);
          Team_Players.Add(team);

    }
    public void AddTeam(int Index)
    {
        int i = 0;
       // GameObject GetTeam =

        Vector3 pos = positon_History_Team_Players[Mathf.Max(i, positon_History_Team_Players.Count - 1)];
        GameObject team = Instantiate(List_Team_Player_Spawn[Index], pos, Quaternion.identity);
        Team_Players.Add(team);

    }
    public void positon_History()
    {
        positon_History_Team_Players.Insert(0, transform.position);
    }
    public void MoveHistory(Current_Positon dir, GameObject target)
    {
        int degree = 0;
        switch
        (dir)
        {
            case Current_Positon.Up:
                degree = 0;
               target.transform.eulerAngles = new Vector3(0, degree, 0);
                break;
            case Current_Positon.Left:
                degree = -90;
                target.transform.eulerAngles = new Vector3(0, degree, 0);
                break;
            case Current_Positon.Right:
                degree = 90;
                target.transform.eulerAngles = new Vector3(0, degree, 0);
                break;
            case Current_Positon.Down:
                degree = 180;
                target.transform.eulerAngles = new Vector3(0, degree, 0);
                break;
        }
    }
    public void Delete_History()
    {

        for (int i = Team_Players.Count+1; i < Move_History.Count; i++)
        {
            Move_History.RemoveAt(i);
        }
        for (int i = Team_Players.Count+1; i < positon_History_Team_Players.Count; i++)
        {
            positon_History_Team_Players.RemoveAt(i);
        }

    }
    public void Chang_MyTeam()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            GameObject frontMyTeam = Team_Players[0];
            Team_Players.RemoveAt(0);
            Team_Players.Add(frontMyTeam);
            //Team_Players.Reverse();

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            GameObject BackMyTeam = Team_Players[Team_Players.Count - 1];
           
            Team_Players.RemoveAt(Team_Players.Count - 1);
            Team_Players.Insert(0,BackMyTeam);
        }
    }
    public void MyTeamDie()
    {
        //    for (int i = 0; i < Team_Players.Count; i++)
        //{
        //    Destroy
        //}
    }


    
}
