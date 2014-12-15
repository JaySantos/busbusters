using System;
using System.Collections;
using UnityEngine;

public class Stop
{
	//Specific Bus Stop information
	public String 					stop_id; //Unique ID
	public String 					address; //Address
	public float					lat; //latitude
	public float					lon; //longitude
	public int						dist; //?
	public Factions.FactionsList 	owner; //Which faction controls this stop
	public int						guardDogs;
	public int						ice;
}
