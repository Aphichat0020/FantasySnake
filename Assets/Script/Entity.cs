using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int Index = 0;
    
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == ("Team"))
        {
            if (this.gameObject.tag == ("EntityTeam"))
            {
                spawn_Entity.instance.spawn_MyTeam_Entity();
                PlayerController.instance.AddTeam(Index);
                Destroy(this.gameObject);
            }
            if (this.gameObject.tag == ("EntityEnemy"))
            {
                Battle();
            }
        }
        if (collider.gameObject.tag == ("wall"))
        {
            Debug.Log("wall");
            PlayerController.instance.Action_Hit();

            Destroy(PlayerController.instance.Team_Players[0]);
            PlayerController.instance.Team_Players.RemoveAt(0);

        }
        if (collider.gameObject.tag == ("Team"))
        {
            if (PlayerController.instance.Team_Players[0])
            {
              
            }
            else
            {
                Debug.Log("Game Over" + name + collider.name);
                UI_Manager.instance.UI_End_Game();
                PlayerController.instance.can_UseController = false;
            }
        }
    }
    public void Battle()
    {
        Status_Player playerAttck = PlayerController.instance.Team_Players[0].GetComponent<Status_Player>();

        playerAttck.TakeDamage(Status_Enemy.instance.Attack_Enemy);

        Status_Enemy.instance.TakeDamage(playerAttck.Attack_Player);
        //win Player alive Enemy Die
        if (playerAttck.Healt_Player > 0 && Status_Enemy.instance.Healt_Enemy <= 0)
        {
            UI_Manager.instance.AddAmount_EnemyDie();
            spawn_Entity.instance.spawn_Enemy_Entity();
            Destroy(this.gameObject);
            Debug.Log("win1");
        }
        // lose Player Die Enemy Alive
        else if (playerAttck.Healt_Player <= 0 && Status_Enemy.instance.Healt_Enemy > 0)
        {
            PlayerController.instance.Action_Hit();
            Destroy(PlayerController.instance.Team_Players[0]);
            PlayerController.instance.Team_Players.RemoveAt(0);
            Debug.Log("lose");
        }
        //Battle Player Alive Enemy Alive
        else if (playerAttck.Healt_Player > 0 && Status_Enemy.instance.Healt_Enemy > 0)
        {
            PlayerController.instance.Action_Hit();
        }
        else
        {
            spawn_Entity.instance.spawn_Enemy_Entity();
            Destroy(PlayerController.instance.Team_Players[0]);
            PlayerController.instance.Team_Players.RemoveAt(0);
            Destroy(this.gameObject);
            PlayerController.instance.Action_Hit();
            Debug.Log("Battle");
           
        }

    }
}
