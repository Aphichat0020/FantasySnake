using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class Status_Player : MonoBehaviour
{
    public static Status_Player instance;
    [Header("Status")]
    public int Healt_Player;
    public int Attack_Player;

    [Header("Min Random Status")]
    public int Min_Random_Start_Healt_Player;
    public int Min_Random_Start_Attack_Player;

    [Header("Max Random Status")]
    public int Max_Random_Start_Healt_Player;
    public int Max_Random_Start_Attack_Player;

    [Header("Random Status LevelUP")]
    public int Random_Healt_LevelUP;
    public int Random_Attack_LevelUP;

    [Header("Max Status")]
    public int Max_Healt_Player;
    public int MaX_Attack_Player;

    [Header("Text Status")]
    public TextMeshProUGUI Text_Healt_Player;
    public TextMeshProUGUI Text_Attack_Player;

    public GameObject camera;
    public Transform HP_Text_to_Rotate;
    public Transform ATK_Text_to_Rotate;

    public float currentTime;
    public float StartTime;

    public bool MaxState;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
    public void Start()
    {
        Random_Status_Player();
        currentTime = StartTime;
    }
    public void Update()
    {
        camera = GameObject.Find("Main Camera");
        
        if(Healt_Player != Max_Healt_Player && Attack_Player != MaX_Attack_Player)
        {
            MaxState = false;

            if (!MaxState)
            {
                currentTime -= 1 * Time.deltaTime;
                if (currentTime < 0)
                {
                    Level_Up_Status_player();
                    currentTime = StartTime;

                }
            }
        }
        
        Text_Healt_Player.text = "HP : "+ Healt_Player.ToString();
        Text_Attack_Player.text = "ATK : " + Attack_Player.ToString();

        HP_Text_to_Rotate.rotation = Quaternion.Slerp(HP_Text_to_Rotate.rotation, camera.transform.rotation, 100f * Time.deltaTime);
        ATK_Text_to_Rotate.rotation = Quaternion.Slerp(ATK_Text_to_Rotate.rotation,camera.transform.rotation, 100f * Time.deltaTime);
    }
    
    public void Random_Status_Player()
    {
        Healt_Player = Random.Range(Min_Random_Start_Healt_Player, Max_Random_Start_Healt_Player);
        Attack_Player = Random.Range(Min_Random_Start_Attack_Player, Max_Random_Start_Attack_Player);
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
            MaxState = true;
        }
    }

    public void TakeDamage(int Damage)
    {
        Healt_Player = Healt_Player - Damage;
        if (Healt_Player <= 0)
        {
            Healt_Player = 0;
        }
    }
    

}