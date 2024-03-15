using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Entity : MonoBehaviour
{
    public static spawn_Entity instance;
    public GameObject Player;
    public Vector3 StartPosition_Player = new Vector3();

    public List<GameObject> Myteam_Entity = new List<GameObject>();

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
    public void spawnPlayer()
    {
        Instantiate(Player, StartPosition_Player, Quaternion.identity);
        PlayerController.instance.can_UseController = true;

    }
    public void spawn_MyTeam_Entity()
    {
        int n = Random.Range(0, Myteam_Entity.Count);
        int p = Random.Range(0, n);

        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);

        Instantiate(Myteam_Entity[n], new Vector3(Random.Range(1, 15), 0, (Random.Range(1, 15))), randomRotation);
    }
    
}
