using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class StaticStopsData 
{
	public struct Stop
	{
		public Vector2 coord;
		public string name;
	}

	public static List<Stop> stops; 

	public static void PopulateData()
	{
		stops = new List<Stop>();

		Stop s1 = new Stop();
		s1.coord = new Vector2(-46.635259f, -23.589337f);
		s1.name = "Metrô Vila Mariana";

		stops.Add(s1);

		Stop s2 = new Stop();
		s2.coord = new Vector2(-46.635235f, -23.589394f);
		s2.name = "R. Domingos De Morais";

		stops.Add(s2);

		Stop s3 = new Stop();
		s3.coord = new Vector2(-46.634769f, -23.588925f);
		s3.name = "Av. Prof. Noé Azevedo, 260";

		stops.Add(s3);

	}
}
