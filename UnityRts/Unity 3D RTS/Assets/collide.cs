using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class collide : MonoBehaviour {

    private List<Collider> col = new List<Collider>();
    private Player player;
    private ShowUnitInfo health;
    public float AttackDamage = 1;

    private void Start()
    {
        player = GetComponent<Player>();
        health = GetComponent<ShowUnitInfo>();

        foreach(var c in GetComponents<Collider>())
        {
            col.Add(c);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if ( player.Info.IsAi )
        {
            if (col.Contains(other))
            {
                Debug.Log("do nothing");
            }
            else
            {
                if(other.tag == "Impact")
                {
                    health.CurrentHealth -= AttackDamage;
                    Destroy(other.gameObject);
                }
            }
        }
        else
        {
            if (col.Contains(other))
            {
                Debug.Log("do nothing");
            }
            else
            {
                if(other.tag == "AiImpact")
                {
                    health.CurrentHealth -= AttackDamage;
                    Destroy(other.gameObject);
                }
            }

        }

 
       // Debug.Log("collide " + gameObject.name + " triggered by " + other.name);

    }

    
    }