using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StopInfoGUIController : MonoBehaviour 
{
	public GameObject stopName;
	public GameObject controlledBy;
	public GameObject guardDogs;
	public GameObject ices;

	private Animator 	stopInfoAnimator;
	private Text 		stopNameText;
	private Text		controlledByText;
	private Text		guardDogsText;
	private Text		icesText;

	// Use this for initialization
	void Start () 
	{
		stopInfoAnimator = gameObject.GetComponent<Animator>();
		stopNameText = stopName.GetComponent<Text>();
		controlledByText = controlledBy.GetComponent<Text>();
		guardDogsText = guardDogs.GetComponent<Text>();
		icesText = ices.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void ShowInfo(bool b)
	{
		stopInfoAnimator.SetBool("showInfo", b);
	}

	public void SetStopInfo(string stopName, Factions.FactionsList owner, int guardDogs, int ices)
	{
		stopNameText.text = stopName;
		string s = "Controlado por: ";
		switch (owner)
		{
		case Factions.FactionsList.Hackers:
			s = s + "Hackers";
			break;
		case Factions.FactionsList.Hippies:
			s = s + "Hippies";
			break;
		case Factions.FactionsList.Neutral:
			s = s + "Neutros";
			break;
		}
		controlledByText.text = s;
		guardDogsText.text = "Cães de guarda: " + guardDogs.ToString();
		icesText.text = "Gelos: " + ices.ToString();
	}
}
