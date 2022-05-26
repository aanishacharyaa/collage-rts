using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnNoHealth : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public ShowUnitInfo info;
    public ActionSelect actions;

    void Start()
    {
        info = GetComponent<ShowUnitInfo>();
        actions = GetComponent<ActionSelect>();
    }

    void Update()
    {
        if (info.CurrentHealth <= 0)
        {
            
            info.Deselect();
            //actions.Deselect();
            ActionsManager.Current.ClearButtons();
            Destroy(this.gameObject);
            var ex =GameObject.Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(ex, 5);
        }
    }


   

}