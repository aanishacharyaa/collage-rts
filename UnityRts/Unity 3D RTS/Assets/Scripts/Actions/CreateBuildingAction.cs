using UnityEngine;
using System.Collections;
using System;

public class CreateBuildingAction : ActionBehaviour {

    public float Cost=200;
    public GameObject GhostBuildingPrefab;
	public GameObject BuildingPrefab;
	public float MaxBuildDistance = 30;
    private GameObject active = null;

	 

    public override Action GetCickAction()
    {
        return delegate () {
            var player = GetComponent<Player>().Info;

            if (player.Credits < Cost)
            {

                Debug.Log("Not enough credits " + Cost);
                return;
            }

            var go = GameObject.Instantiate(GhostBuildingPrefab);
            var finder = go.AddComponent<FindBuildingSite>();
            finder.BuildingPrefab = BuildingPrefab;
            finder.MaxBuildDistance = MaxBuildDistance;
            finder.Info = player;
            finder.Source = transform;
            finder.Cost = Cost;
            active = go;
        };
    }


    private void Update()
    {
        if (active == null) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Destroy(active);
        }
    }


    private void OnDestroy()
    {
        if (active == null) return;

        GameObject.Destroy(active);
    }






}
