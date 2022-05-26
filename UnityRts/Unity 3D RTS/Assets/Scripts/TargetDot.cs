using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDot : MonoBehaviour {
    public GameObject DotPrefab;
    private GameObject Dot;
	public static TargetDot Current;

    public TargetDot()
    {
        Current = this;
    }

    public void make(Vector3 target)
    {
        Dot = GameObject.Instantiate(DotPrefab,target, Quaternion.identity);
    }

    
    public void destroyIt()
    {
        if (Dot == null) return;
        GameObject.Destroy(Dot);
    }
}
