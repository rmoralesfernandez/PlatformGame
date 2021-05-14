﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAreaController : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collider2D)
    {
		if(collider2D.tag == "Player")
		{
			collider2D.GetComponent<carmove>().Dead();
		}
    }
}
