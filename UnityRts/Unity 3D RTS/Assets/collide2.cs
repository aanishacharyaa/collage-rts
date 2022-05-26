using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide2 : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Player>().Info.IsAi)
        {
            Destroy(other.gameObject);
        }

        Debug.Log("collide2 " +gameObject.name + " triggered by " + other.name);

    }
}
