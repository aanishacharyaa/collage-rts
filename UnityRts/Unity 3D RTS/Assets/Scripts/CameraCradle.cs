using UnityEngine;
using System.Collections;

public class CameraCradle : MonoBehaviour {

	public float Speed = 20;
    public float Hight = 80;
    private float scrolln = 0;
    //public float scrollp = 0;



    public float scroll()
    {
        float a = Input.mouseScrollDelta.y;

        if (a == 0) return 0;

        if(Mathf.Sign(a) == 1)
        {
            if (scrolln >= 4)
            {
                return 0;
            }
            else
            {
                if (a > 1) a = 1;
                scrolln = scrolln + a;
                return a;
            }


        }
        else
        {
           

            if (scrolln <= 0)
            {
                return 0;
            }
            else
            {
                if (a < -1) a = -1;
                scrolln = scrolln + a;
                return a;
            }
        }
        
    }


    

	// Use this for initialization
	void Start () {
	 foreach(var p in RtsManager.Current.Players)
        {
            if (p.IsAi) continue;

            var pos = p.Location.position;
            pos.y = Hight;
            transform.position = pos;
        }
	}
	
	// Update is called once per frame
	void Update () {

       // Debug.Log("mouse Scroll delta : "+Input.mouseScrollDelta.y);




        transform.Translate(
            Input.GetAxis("Horizontal") * Speed * Time.deltaTime,
            Input.GetAxis("Vertical") * Speed   * Time.deltaTime,
            scroll() * Speed 
            );
	}
}
