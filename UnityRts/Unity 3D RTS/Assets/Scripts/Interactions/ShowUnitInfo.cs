using UnityEngine;
using System.Collections;

public class ShowUnitInfo : Interaction {

	public string Name;
	public float MaxHealth, CurrentHealth;
	public Sprite ProfilePic;

    bool selected = false;

	public override void Select ()
	{
        selected = true;

    }

    private void Update()
    {
         if (!selected) return;
        
            InfoManager.Current.SetPic(ProfilePic);
            InfoManager.Current.SetLines(
                Name,
                CurrentHealth + "/" + MaxHealth,
                "Owner: " + GetComponent<Player>().Info.Name);
       
    }

    public override void Deselect ()
	{
        selected = false;
		InfoManager.Current.ClearPic ();
		InfoManager.Current.ClearLines ();
	}

    
}
