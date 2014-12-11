using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using JsonFx.Json;

public class StopsDataReader : MonoBehaviour 
{
	public TextAsset stopsData;

	public string dataString;

	public void Start()
	{
	}

	public void PopulateStopInfo()
	{
		dataString = stopsData.text;
		
		var response = JsonReader.Deserialize<Stop[]> (dataString);
		
		foreach (var v in response)
		{
			Stop s = new Stop();
			s.stop_id = v.stop_id;
			s.address = v.address;
			s.lat = v.lat;
			s.lon = v.lon;
			s.dist = v.dist;
			Stops.stops.Add(s);
		}

		foreach (Stop s in Stops.stops)
		{
			Debug.Log(s.address + " " + s.stop_id);
		}
	}
}