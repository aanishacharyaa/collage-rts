using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashBoxManager : MonoBehaviour {

	public Text CashField;
    public Text Fps;
    int c = 0;
   
     

    // Update is called once per frame
    void Update () {

        CashField.text = "$ " + (int)Player.Default.Credits;
        c++;
        
	}

    void show()
    {
        Fps.text = "Fps : " + c;
        c = 0;

    }

    private void Start()
    {
        InvokeRepeating("show", 0.1f, 1f);
    }
}
