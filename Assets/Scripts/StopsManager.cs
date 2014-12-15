using UnityEngine;
using System.Collections;

public class StopsManager : MonoBehaviour 
{
	public GameObject stopModel;

	public void DrawStops()
	{
		//foreach (StaticStopsData.Stop s in StaticStopsData.stops)
		foreach (Stop s in Stops.stops)
		{
			GameObject go = Instantiate(stopModel, Vector3.zero, Quaternion.identity) as GameObject;
			SetGeolocation sg = go.GetComponent<SetGeolocation>();
			sg.lat = s.lat;
			sg.lon = s.lon;
			go.transform.localScale = new Vector3 (10f, 10f, 10f);
			StopUniqueID uid = go.GetComponent<StopUniqueID>();
			uid.stop_id = s.stop_id;
		}
	}
}
