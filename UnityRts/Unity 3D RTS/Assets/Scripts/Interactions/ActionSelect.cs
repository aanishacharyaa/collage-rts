using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionSelect : Interaction {

    
 
 

	public override void Deselect ()
	{
		ActionsManager.Current.ClearButtons ();
	}

	public override void Select ()
	{
		ActionsManager.Current.ClearButtons ();
		foreach (var ab in GetComponents<ActionBehaviour>()) {

			ActionsManager.Current.AddButton(
				ab.ButtonPic, 
				ab.GetCickAction());

            
        }
        
    }

    
}
