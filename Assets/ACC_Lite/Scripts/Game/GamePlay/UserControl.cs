﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (CarController))]
public class UserControl :MonoBehaviour
{

	CarController ControlledCar;

	public float Horizontal { get; private set; }
	public float Vertical { get; private set; }
	public bool Brake { get; private set; }

	public static MobileControlUI CurrentUIControl { get; set; }

	private void Awake ()
	{
		ControlledCar = GetComponent<CarController> ();
		CurrentUIControl = FindObjectOfType<MobileControlUI> ();
	}

	void Update ()
	{
		if (CurrentUIControl != null && CurrentUIControl.ControlInUse)
		{
			
			Horizontal = CurrentUIControl.GetHorizontalAxis;
			Vertical = CurrentUIControl.GetVerticalAxis;
		}
		else
		{
			
			Horizontal = SimpleInput.GetAxis ("Horizontal");
			Vertical = SimpleInput.GetAxis ("Vertical");
			Brake = SimpleInput.GetButton ("Jump");
		}

		
		ControlledCar.UpdateControls (Horizontal, Vertical, Brake);
	}
}
