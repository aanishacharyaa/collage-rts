using System.Collections;
 
using UnityEngine;

public abstract class AiBehaviour : MonoBehaviour {

    public float WeightMultipler = 1;
    public float TimePassed = 0;

    public abstract float GetWeight();
    public abstract void Execute();
}
