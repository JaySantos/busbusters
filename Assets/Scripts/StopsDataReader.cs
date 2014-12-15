using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using JsonFx.Json;

public class StopsDataReader : MonoBehaviour 
{
	public TextAsset stopsData;	//File with stops info. TO BE DELETED

	public string dataString; //String with stops data. TO BE DELETED

	public void Start()
	{
	}

	public void PopulateStopInfo()
	{
		//Reading the file
		dataString = stopsData.text;
		
		var response = JsonReader.Deserialize<Stop[]> (dataString);

		//Populatins the stops list
		foreach (var v in response)
		{
			Stop s = new Stop();
			s.stop_id = v.stop_id;
			s.address = v.address;
			s.lat = v.lat;
			s.lon = v.lon;
			s.dist = v.dist;
			Stops.stops.Add(s);
			//Who owns this point? TO BE DELETED
			int owner = UnityEngine.Random.Range(0, 100);
			if (owner % 3 == 0)
			{
				s.owner = Factions.FactionsList.Hackers;
			}
			else if (owner % 3 == 1)
			{
				s.owner = Factions.FactionsList.Hippies;
			}
			else if (owner % 3 == 2)
			{
				s.owner = Factions.FactionsList.Neutral;
			}
			s.guardDogs = UnityEngine.Random.Range(0, 50);
			s.ice = UnityEngine.Random.Range(0, 50);
		}
	}
}