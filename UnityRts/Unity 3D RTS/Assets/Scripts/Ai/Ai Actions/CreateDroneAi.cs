using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDroneAi : AiBehaviour {

    public int DronePerBase = 5;
    public float Cost = 30;
    private AiSupport support=null;

    public override float GetWeight()
    {
        if (support == null)
        {
            support = AiSupport.GetSupport(gameObject);
        }
        if (support.player.Credits < Cost)
        {
            return 0;
        }

        var drones = support.Drones.Count;
        var bases = support.CommandBase.Count;

        if(bases==0)
        {
            return 0; 
        }
        if (drones >= bases * DronePerBase)
        {
            return 0;
        }

        return 1;
    }

    public override void Execute()
    {
        Debug.Log(support.player.Name + " is creating Drone!");

        var bases = support.CommandBase;
        var index = UnityEngine.Random.Range(0, bases.Count);
        var commandbase = bases[index];
        commandbase.GetComponent<CreateUnitAction>().GetCickAction()();
    }
}
