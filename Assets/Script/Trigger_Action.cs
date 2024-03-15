using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Action : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == ("wall"))
        {
            PlayerController.instance.Action_Hit_Player();
          
            Destroy(PlayerController.instance.Team_Players[0]);
            PlayerController.instance.Team_Players.RemoveAt(0);

        }
        if (collider.gameObject.tag == ("EntityTeam"))
        {

        }
        
       
        if (collider.gameObject.tag == ("Enemy"))
        {

        }
        if (collider.gameObject.tag == ("Team"))
        {
          if(PlayerController.instance.Team_Players[0] == collider.gameObject)
            {
            }
            else
            {
                Debug.Log("Game Over"+ name + collider.name);
                UI_Manager.instance.UI_End_Game();
                PlayerController.instance.can_UseController = false;
            }

          
        }
    }
}
