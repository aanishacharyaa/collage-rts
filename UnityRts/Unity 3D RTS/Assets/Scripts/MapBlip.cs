using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MapBlip : MonoBehaviour {

    private GameObject Blip;

    public GameObject BilpGet
    {
        get
        {
            return Blip;
        }
    }

 	void Start () {
        Blip = GameObject.Instantiate(Map.Current.BlipPrefab);
        //New Method Of setting parent Below
        Blip.transform.SetParent(Map.Current.transform);
        var Color = GetComponent<Player>().Info.AccentColor;
        Blip.GetComponent<Image>().color = Color;
	}
	
	 
	void Update () {
        Blip.transform.position = Map.Current.WorldPositionToMap(transform.position);
	}

    private void OnDestroy()
    {
        GameObject.Destroy(Blip);
    }
}
