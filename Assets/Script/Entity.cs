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
                UI_Manager.instance.AddAmount_EnemyDie();
                Destroy(this.gameObject);
                spawn_Entity.instance.spawn_Enemy_Entity();
            }
        }
    }
}
