using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {

    public string PlayerName;
    public float Confussion = 0.3f;
    public float Frequency = 1f;

    private PlayerSetupDefinition player;
    public float waited = 0;

    public PlayerSetupDefinition Player { get { return player; } }

    private List<AiBehaviour> Ais = new List<AiBehaviour>();

 	void Start () {
		foreach(var ai in GetComponents<AiBehaviour>())
        {
            Ais.Add(ai);
        }

        foreach(var p in RtsManager.Current.Players)
        {
            if(p.Name == PlayerName)
            {
                player = p;
            }
        }

        gameObject.AddComponent<AiSupport>().player = player;
        
	}

       
	
 	void Update () {

        waited += Time.deltaTime;
        if (waited < Frequency)
        {
            return;
        }

        //string ailog = "";

        float bestAiValue = float.MinValue;
        AiBehaviour bestAi = null;
        AiSupport.GetSupport(gameObject).Refresh();

        foreach(var ai in Ais)
        {
            ai.TimePassed += waited;
            var aiValue = ai.GetWeight() * ai.WeightMultipler + Random.Range(0,Confussion);
           // ailog += ai.GetType().Name + " : " + aiValue + " \n";
            if (aiValue > bestAiValue)
            {
                bestAiValue = aiValue;
                bestAi = ai;
            }
        }
      //  Debug.Log(ailog);
        bestAi.Execute();
        waited = 0;

	}

    
}
