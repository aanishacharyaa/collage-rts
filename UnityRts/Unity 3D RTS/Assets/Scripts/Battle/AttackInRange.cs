using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour
{
    [SerializeField]
    private Transform[] firepoints;
    public float launchForce = 700f;
    public GameObject ImpactVisual;
    public GameObject AiImpactVisual;
    public float FindTargetDelay = 1;
    public float AttackRange = 20;
    public float AttackFrequency = 0.25f;
    

    private ShowUnitInfo target;
    public PlayerSetupDefinition player;
    public float findTargetCounter = 0;
    public float attackCounter = 0;

    bool OnAttack = false;

    void Start()
    {
        player = GetComponent<Player>().Info;
        
        
    }

    void FindTarget()
    {
        if (target != null) return;

        foreach (var p in RtsManager.Current.Players)
        {
            if (p == null) return;
            if (p == player) continue;

            foreach (var unit in p.ActiveUnits)
            {
                if (Vector3.Distance(unit.transform.position, transform.position) < AttackRange)
                {
                    target = unit.GetComponent<ShowUnitInfo>();

                    return;
                }
            }

        }

    }


    void Attack()
    {
        if (target == null) return;

        if (Vector3.Distance(target.transform.position, transform.position) > AttackRange)
        {
            target = null;
            return;
        }


        OnAttack = true;

        if (player.IsAi)
        {
            foreach (var v in firepoints)
            {
                

                

                var fire = GameObject.Instantiate(AiImpactVisual, v.transform.position, Quaternion.identity);
                fire.GetComponent<MeshRenderer>().material.color = player.AccentColor;
                
                fire.GetComponent<Rigidbody>().AddForce(v.forward * launchForce);

                Destroy(fire, 6);

            }

        }
        else
        {

            foreach (var v in firepoints)
            {
               
              

                var fire = GameObject.Instantiate(ImpactVisual, v.transform.position, Quaternion.identity);
                fire.GetComponent<MeshRenderer>().material.color = player.AccentColor;

                fire.GetComponent<Rigidbody>().AddForce(v.forward * launchForce);

                Destroy(fire, 6);

            }
        }

        

        

        //GameObject.Instantiate(ImpactVisual, target.transform.position, Quaternion.identity);
        //target.CurrentHealth -= AttackDamage;
    }

   



    public void forceAttack()
    {

        attackCounter += Time.deltaTime;
        if (attackCounter > AttackFrequency)
        {

            attackCounter = 0;

            //obj.GetComponent<ShowUnitInfo>().CurrentHealth -= AttackDamage;


            OnAttack = true;

            if (player.IsAi)
            {
                foreach (var v in firepoints)
                {




                    var fire = GameObject.Instantiate(AiImpactVisual, v.transform.position, Quaternion.identity);
                    fire.GetComponent<MeshRenderer>().material.color = player.AccentColor;

                    fire.GetComponent<Rigidbody>().AddForce(v.forward * launchForce);

                    Destroy(fire, 6);

                }

            }
            else
            {

                foreach (var v in firepoints)
                {



                    var fire = GameObject.Instantiate(ImpactVisual, v.transform.position, Quaternion.identity);
                    fire.GetComponent<MeshRenderer>().material.color = player.AccentColor;

                    fire.GetComponent<Rigidbody>().AddForce(v.forward * launchForce);

                    Destroy(fire, 6);

                }
            }
        }
    }

    void Update()
    {

         

               if (OnAttack)
               { 

                   if (target != null) { gameObject.transform.LookAt(target.transform); }

               }

               findTargetCounter += Time.deltaTime;
               if(findTargetCounter > FindTargetDelay)
               {
                   FindTarget();
                   findTargetCounter = 0;
               }

               attackCounter += Time.deltaTime;
               if(attackCounter > AttackFrequency)
               {
                   Attack();
                   attackCounter = 0;
               }
           }

           

    }

