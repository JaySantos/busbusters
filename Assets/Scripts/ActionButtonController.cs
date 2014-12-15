using UnityEngine;
using System.Collections;

public class ActionButtonController : MonoBehaviour 
{
	public GameObject attackStopButton;
	public GameObject tagBusButton;
	public GameObject setComputerButton;

	private Animator attackStopAnimator;
	private Animator tagBusAnimator;
	private Animator setComputerAnimator;

	// Use this for initialization
	void Start () 
	{
		attackStopAnimator = attackStopButton.GetComponent<Animator>();
		tagBusAnimator = tagBusButton.GetComponent<Animator>();
		setComputerAnimator = setComputerButton.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void ShowHideButtons()
	{
		attackStopAnimator.SetTrigger("switch");
		tagBusAnimator.SetTrigger("switch");
		setComputerAnimator.SetTrigger("switch");
	}
}
