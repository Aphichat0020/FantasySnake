using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawn_Entity : MonoBehaviour
{
    public static spawn_Entity instance;

    public GameObject Player;
    public Vector3 StartPosition_Player = new Vector3();

    public List<GameObject> Myteam_Entity = new List<GameObject>();
    public List<GameObject> Enemy_Entity = new List<GameObject>();

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
        int T = Random.Range(0, Myteam_Entity.Count);
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
        Instantiate(Myteam_Entity[T], new Vector3(Random.Range(1, 15), 0, (Random.Range(1, 15))), randomRotation);

    }
    public void spawn_Enemy_Entity()
    {
        int E = Random.Range(0, Enemy_Entity.Count);
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
        Instantiate(Enemy_Entity[E], new Vector3(Random.Range(1, 15), 0, (Random.Range(1, 15))), randomRotation);
    }
}
