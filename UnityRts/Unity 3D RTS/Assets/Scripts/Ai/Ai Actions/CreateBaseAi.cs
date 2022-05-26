using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBaseAi : AiBehaviour
{

    private AiSupport support = null;
    public float Cost = 200;
    public int UnitsPerBase = 5;

    public override float GetWeight()
    {
        if (support == null)
        {
            support = AiSupport.GetSupport(gameObject);
        }

        if (support.player.Credits < Cost || support.Drones.Count == 0)
        {
            return 0;
        }


        if(support.CommandBase.Count * UnitsPerBase <= support.Drones.Count)
        {
            return 1;
        }
        return 0;

        /*
        if (support.CommandBase.Count == 0)
        {
            return 1;
        }

        return (support.CommandBase.Count / UnitsPerBase) * support.Drones.Count;
        */
    }


    public float RangeFromDrone = 30;
    public int TriesPerDrone = 3;
    public GameObject BasePrefab;

    public override void Execute()
    {
        Debug.Log("creating base!");
        var go = GameObject.Instantiate(BasePrefab);
        go.AddComponent<Player>().Info = support.player;

        foreach (var drone in support.Drones)
        {
            for (int i = 0; i < TriesPerDrone; i++)
            {
                var pos = drone.transform.position;
                pos += UnityEngine.Random.insideUnitSphere * RangeFromDrone;
                pos.y = Terrain.activeTerrain.SampleHeight(pos);
                go.transform.position = pos;

                if (RtsManager.Current.IsGameObjectSafeToPlace(go)){
                    support.player.Credits -= Cost;
                    return;
                }
            }
        }

        Destroy(go);
    }

}
