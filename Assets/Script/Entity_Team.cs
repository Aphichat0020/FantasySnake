using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Team : MonoBehaviour
{
    public int Index = 0;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == ("Team"))
        {
         

            Destroy(this.gameObject);
            spawn_Entity.instance.spawn_MyTeam_Entity();

            PlayerController.instance.AddTeam(Index);

        }
    }
}
