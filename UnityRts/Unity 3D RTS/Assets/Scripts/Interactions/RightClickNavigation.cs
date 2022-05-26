using UnityEngine;
using System.Collections;
 
using UnityEngine.AI;

public class RightClickNavigation : Interaction {

    public static RightClickNavigation Current;

    public RightClickNavigation()
    {
        Current = this;
    }
	public float RelaxDistance = 5;

	private NavMeshAgent agent;
	private Vector3 target = Vector3.zero;
	private bool selected = false;
	private bool isActive = false;

	public override void Deselect ()
	{
		selected = false;
	}

	public override void Select ()
	{
		selected = true;
	}

    public void SendToTarget(Vector3 pos)
    {
        target = pos;
        SendToTarget();
    }

	public void SendToTarget()
	{
		agent.SetDestination (target);
		agent.Resume ();
		isActive = true;
	}

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (selected && Input.GetMouseButtonDown (1)) {

            var es = UnityEngine.EventSystems.EventSystem.current;
            if (es != null && es.IsPointerOverGameObject())
                return;

            var tempTarget = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
			if (tempTarget.HasValue) {
                target = tempTarget.Value;
                TargetDot.Current.destroyIt();
                TargetDot.Current.make(target);
                SendToTarget();
			}
		}

		if (isActive && Vector3.Distance (target, transform.position) < RelaxDistance) {
            TargetDot.Current.destroyIt();
			agent.Stop ();
			isActive = false;
		}
	}
}
