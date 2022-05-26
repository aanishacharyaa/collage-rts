using System;
using System.Collections;
 
using UnityEngine;

public class CreateUnitAction : ActionBehaviour {

    public GameObject Prefab;
    public float Cost = 30;
    private PlayerSetupDefinition player;

    public override Action GetCickAction()
    {
        return delegate ()
        {
            if (player.Credits < Cost)
            {
                Debug.Log("Not enough credites to create unit " + Cost);
                return;
            }
            var go = (GameObject)GameObject.Instantiate(Prefab,
                transform.position,
                Quaternion.identity
                );
            go.AddComponent<Player>().Info = player;
            go.AddComponent<RightClickNavigation>();
            go.AddComponent<ActionSelect>();
            player.Credits -= Cost;
        };
        }
    

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>().Info;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
