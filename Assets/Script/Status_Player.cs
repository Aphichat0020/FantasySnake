using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Player : MonoBehaviour
{
    [Header("Status")]
    public int Healt_Player;
    public int Attack_Player;

    [Header("Min Random Status")]
    public int Min_Random_Start_Healt_Player;
    public int Min_Random_Start_Attack;

    [Header("Max Random Status")]
    public int Max_Random_Start_Healt_Player;
    public int Max_Random_Start_Attack;

    [Header("Random Status LevelUP")]
    public int Random_Healt_LevelUP;
    public int Random_Attack_LevelUP;

    [Header("Max Status")]
    public int Max_Healt_Player;
    public int MaX_Attack_Player;


    public float currentTime;
    public float StartTime;  

    public void Start()
    {
        Random_Status_Player();
        currentTime = StartTime;
    }
    public void Update()
    {
        currentTime -= 1 *Time.deltaTime;
        if(currentTime <= 0)
        {
            Level_Up_Status_player();
            currentTime = StartTime;

        }
    }

    public void Random_Status_Player()
    {
        Healt_Player = Random.Range(Min_Random_Start_Healt_Player, Max_Random_Start_Healt_Player);
        Attack_Player = Random.Range(Min_Random_Start_Attack, Max_Random_Start_Attack);
    }
    public void Level_Up_Status_player()
    {
        Healt_Player = Healt_Player + Random.Range(0, Random_Healt_LevelUP);
        Attack_Player = Attack_Player + Random.Range(0, Random_Attack_LevelUP);

        if (Healt_Player >= Max_Healt_Player)
        {
            Healt_Player = Max_Healt_Player;
        }
        if (Attack_Player >= MaX_Attack_Player)
        {
            Attack_Player = MaX_Attack_Player;
            currentTime = 0;
            StartTime = 0;
        }
    }

}