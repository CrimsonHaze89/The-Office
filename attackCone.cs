using UnityEngine;
using System.Collections;

public class attackCone : MonoBehaviour {

    public turret turretAI;

    public bool isLeft = false;

void Awake()
    {
        turretAI = gameObject.GetComponentInParent<turret>();
    }

void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                turretAI.Attack(false);
            }
            else
            {
                turretAI.Attack(true);
            }
        }
    }
}
