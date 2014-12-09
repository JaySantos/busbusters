using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdatePositionController : MonoBehaviour 
{
	public GameObject	textField;
	public GameObject 	stopModel;

	private float		updateTime = 0.5f;
	private int maxWait = 20;
	private int updateCount = 0;
	private Text text;
	private OnlineMapsMarker playerMarker;

	// Use this for initialization
	IEnumerator Start () 
	{
		if (!Input.location.isEnabledByUser)
		{
			Debug.Log("ENABLE LOCATION SERVICES!!!");
			yield return 0;
		}

		Input.location.Start();
		text = textField.GetComponent<Text>();
		text.text = "Initializing... " + maxWait;

		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) 
		{
			yield return new WaitForSeconds(1);
			maxWait--;
			text.text = "Initializing... " + maxWait;
		}

		if (maxWait < 1) 
		{
			text.text = "Timed out";
			Debug.Log("Timed out");
			yield return 0;
		}
		else
		{
			Debug.Log("Service initialized!!!");
		}

		StaticStopsData.PopulateData();
		DrawStops();


		if (Input.location.status == LocationServiceStatus.Failed) 
		{
			Debug.Log("Unable to determine device location");
			text.text = "Unable to localize";
			yield return 0;
		} 
		else
		{
			StartCoroutine ("UpdatePosition");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	IEnumerator UpdatePosition()
	{
		float lat = 0f;
		float longitude = 0f;
		while (true)
		{
			yield return new WaitForSeconds(updateTime);
			//Debug.Log("Location: " + Input.location.lastData.latitude + " - " + Input.location.lastData.longitude + " - " + Input.location.lastData.timestamp);
			text.text = updateCount + ": " + Input.location.lastData.latitude + " - " + Input.location.lastData.longitude;

			if (updateCount == 0)
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
				OnlineMaps.instance.SetPositionAndZoom(longitude, lat, OnlineMaps.instance.zoom);
				OnlineMaps.instance.Redraw();
			}
			updateCount++;
		}
	}

	public void DrawStops()
	{
		OnlineMapsMarker3D marker3D;
		// Get instance of OnlineMapsControlBase3D (Texture or Tileset)
		OnlineMapsControlBase3D control = OnlineMaps.instance.GetComponent<OnlineMapsControlBase3D>();


		foreach (StaticStopsData.Stop s in StaticStopsData.stops)
		{
			//Vector2 pos2d = OnlineMapsUtils.LatLongToTilef(api.position, api.zoom);

			//OnlineMapsUtils.LatLongToTilef(api.position, api.zoom);
			OnlineMapsMarker m = OnlineMaps.instance.AddMarker(s.coord, s.name);
			
			// Specifies that marker should be shown only when zoom from 1 to 10.
			//marker3D.range = new OnlineMapsRange(1, 17);
			
			//Debug.Log ("Latlongtotile = " + OnlineMapsUtils.LatLongToTilef(s.coord, OnlineMaps.instance.zoom) * OnlineMapsUtils.tileSize);
		}
	}
}
