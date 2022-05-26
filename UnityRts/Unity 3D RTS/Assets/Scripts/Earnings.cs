using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earnings : MonoBehaviour {

    public float CreditsPerSecond = 1;
    private PlayerSetupDefinition player;
	 
	void Start () {
        player = GetComponent<Player>().Info;
	}
	
 
	void Update () {
        player.Credits += CreditsPerSecond * Time.deltaTime;
	}
}
