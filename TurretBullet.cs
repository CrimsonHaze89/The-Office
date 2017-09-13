using UnityEngine;
using System.Collections;

public class TurretBullet : MonoBehaviour {

void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if(col.name == "Bob")
            {
                //col.GetComponent<Player>().Damage(1);
            }
            Destroy(gameObject);
        }
    }
}
