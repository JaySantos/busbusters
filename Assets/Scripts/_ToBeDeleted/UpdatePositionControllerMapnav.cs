using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdatePositionControllerMapnav : MonoBehaviour 
{
	private float		updateTime = 5f;
	private int maxWait = 20;
	private int updateCount = 0;
	private OnlineMapsMarker playerMarker;

	// Use this for initialization
	IEnumerator Start () 
	{
		if (!Input.location.isEnabledByUser)
		{
			Debug.Log("ENABLE LOCATION SERVICES!!!");
			yield return 0;
		}

		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) 
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		if (maxWait < 1) 
		{
			Debug.Log("!!!!!!!!!!Timed out!!!!!!!!!!");
			yield return 0;
		}
		else
		{
			Debug.Log("!!!!!!!!!!Service initialized!!!!!!!!!!");
		}

		gameObject.GetComponent<StopsDataReader>().PopulateStopInfo();


		if (Input.location.status == LocationServiceStatus.Failed) 
		{
			Debug.Log("Unable to determine device location");
			yield return 0;
		} 
		else
		{
			StartCoroutine ("UpdatePosition");
		}

		GameObject.Find("StopsManager").GetComponent<StopsManager>().DrawStops();
	}

	IEnumerator UpdatePosition()
	{
		float lat = 0f;
		float longitude = 0f;
		while (true)
		{
			yield return new WaitForSeconds(updateTime);
			//GameObject.Find("Map").GetComponent<MapNav>().UpdateMapPosition();
			//Debug.Log("Location: " + Input.location.lastData.latitude + " - " + Input.location.lastData.longitude + " - " + Input.location.lastData.timestamp);

			/*if (updateCount == 0)
			{
				playerMarker = OnlineMaps.instance.AddMarker(new Vector2(Input.location.lastData.longitude, Input.location.lastData.latitude));
				OnlineMaps.instance.SetPositionAndZoom(Input.location.lastData.longitude, Input.location.lastData.latitude, 3);
				lat = Input.location.lastData.latitude;
				longitude = Input.location.lastData.longitude;
			}
			else
			{
				//lat += 1f;
				//longitude += 1f;
				playerMarker.position = new Vector2(Input.location.lastData.longitude, Input.location.lastData.latitude);
				//OnlineMaps.instance.SetPositionAndZoom(longitude, lat, OnlineMaps.instance.zoom);
				//OnlineMaps.instance.Redraw();
			}
			updateCount++;*/
		}
	}
}
