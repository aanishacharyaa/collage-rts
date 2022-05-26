using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSelectAttack : Interaction {

    private bool selected = false;
    public AttackInRange attack;
    
         
    public override void Deselect()
    {
        selected = false;
    }

    public override void Select()
    {
        selected = true;
    }
    
    void Start () {
        attack = GetComponent<AttackInRange>();
	}

    void fire()
    {
        
    }
	
	 
	void Update () {
        if (selected)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                attack.forceAttack();
            }
           
        }
	}
}
