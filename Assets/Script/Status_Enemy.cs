using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Status_Enemy : MonoBehaviour
{
    [Header("Status")]
    public int Healt_Enemy;
    public int Attack_Enemy;

    [Header("Min Random Status")]
    public int Min_Random_Start_Healt_Enemy;
    public int Min_Random_Start_Attack_Enemy;

    [Header("Max Random Status")]
    public int Max_Random_Start_Healt_Enemy;
    public int Max_Random_Start_Attack_Enemy;

    

    [Header("Text Status")]
    public TextMeshProUGUI Text_Healt_Enemy;
    public TextMeshProUGUI Text_Attack_Enemy;

    public GameObject camera;

    public Transform HP_Text_to_Rotate;
    public Transform ATK_Text_to_Rotate;


    void Start()
    {
        Random_Status_Enemy();
    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.Find("Main Camera");

        Text_Healt_Enemy.text = "HP : " + Healt_Enemy.ToString();
        Text_Attack_Enemy.text = "ATK : " + Attack_Enemy.ToString();

        HP_Text_to_Rotate.rotation = Quaternion.Slerp(HP_Text_to_Rotate.rotation, camera.transform.rotation, 100f * Time.deltaTime);
        ATK_Text_to_Rotate.rotation = Quaternion.Slerp(ATK_Text_to_Rotate.rotation, camera.transform.rotation, 100f * Time.deltaTime);


    }
    public void Random_Status_Enemy()
    {
        Healt_Enemy = Random.Range(Min_Random_Start_Healt_Enemy, Max_Random_Start_Healt_Enemy);
        Attack_Enemy = Random.Range(Min_Random_Start_Attack_Enemy, Max_Random_Start_Attack_Enemy);
    }
   
}
