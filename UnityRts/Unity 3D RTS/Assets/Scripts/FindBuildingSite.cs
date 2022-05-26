using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBuildingSite : MonoBehaviour {

    public float Cost;
	public float MaxBuildDistance;
	public GameObject BuildingPrefab;
	public PlayerSetupDefinition Info;
	public Transform Source;


	Renderer rend;
	Color Red = new Color(1,0,0,0.6f);
	Color Green = new Color(0,1,0,0.6f);

	void Start(){
		MouseManager.Current.enabled = false;
        RightClickNavigation.Current.enabled = false;
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
        var tempTarget = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
        if (!tempTarget.HasValue) return;

        transform.position = tempTarget.Value;

		if (Vector3.Distance (transform.position, Source.position) > MaxBuildDistance) {
			rend.material.color = Red;
			return;
		}

		if (RtsManager.Current.IsGameObjectSafeToPlace (gameObject)) {
			rend.material.color = Green;

			if (Input.GetMouseButtonDown (0)) {

                Info.Credits -= Cost;
				var go = GameObject.Instantiate (BuildingPrefab);
				go.transform.position = transform.position;
                go.AddComponent<ActionSelect>();
				go.AddComponent<Player> ().Info = Info;
				Destroy (this.gameObject);
			}
		} else {
			rend.material.color = Red;
		}


	}


	void OnDestroy(){
        
		MouseManager.Current.enabled = true;
        RightClickNavigation.Current.enabled = true;
	}
}
