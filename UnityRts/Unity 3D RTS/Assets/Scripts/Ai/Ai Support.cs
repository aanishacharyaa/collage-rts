using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSupport : MonoBehaviour {

    public List<GameObject> Drones = new List<GameObject>();
    public List<GameObject> CommandBase = new List<GameObject>();
    public PlayerSetupDefinition player = null;

    public static AiSupport GetSupport (GameObject go)
    {
        return go.GetComponent<AiSupport>();
    }

 	 public void Refresh()
    {
        Drones.Clear();
        CommandBase.Clear();
        foreach(var u in player.ActiveUnits)
        {
            if(u.name.Contains("Drone Unit"))
            {
                Drones.Add(u);
            }
            if(u.name.Contains("Command Base"))
            {
                CommandBase.Add(u); 
            }
        }
    }
}
