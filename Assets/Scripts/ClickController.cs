using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour 
{
	public GameObject stopInfo;

	private StopInfoGUIController stopInfoGUIController;
	// Use this for initialization
	void Start () 
	{
		stopInfoGUIController = stopInfo.GetComponent<StopInfoGUIController>();
	}
	
	// In this update I´ll check if the user clicked on a bus stop. If he did we show that stop info.
	void Update () 
	{
		RaycastHit hit;
		//Check if I´m running on the editor or mobile ("#else")
#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
		{
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (r, out hit, 100.0f))
			{
				if (hit.collider.transform.tag == "BusStop") //If I clicked on a bus stop I'll show its information
				{
					StopUniqueID uid = hit.collider.gameObject.GetComponent<StopUniqueID>();
					Stop s = Stops.stops.Find(k => k.stop_id == uid.stop_id);
					stopInfoGUIController.SetStopInfo(s.address, s.owner, s.guardDogs, s.ice);
					stopInfoGUIController.ShowInfo(true);
				}
				else //If I haven´t clicked on a bus stop I'll hide the info
				{
					stopInfoGUIController.ShowInfo(false);
				}
			}
		}
#else
		if (Input.touchCount > 0 )
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Ray r = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
				if (Physics.Raycast (r, out hit, 100.0f))
				{
					if (hit.collider.transform.tag == "BusStop") //If I clicked on a bus stop I'll show its information
					{
						StopUniqueID uid = hit.collider.gameObject.GetComponent<StopUniqueID>();
						Stop s = Stops.stops.Find(k => k.stop_id == uid.stop_id);
						stopInfoGUIController.SetStopInfo(s.address, s.owner, s.guardDogs, s.ice);
						stopInfoGUIController.ShowInfo(true);
					}
					else
					{
						stopInfoGUIController.ShowInfo(false);
					}
				}
			}
		}
#endif
	}
}
