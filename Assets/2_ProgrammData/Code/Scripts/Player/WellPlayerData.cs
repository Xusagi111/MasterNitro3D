using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellPlayerData : MonoBehaviour
{
	[SerializeField] private Wheel[] _wheels;
	public static Action<Wheel[]> EventTransferCarWheel;

	private void Start()
    {
		for (int i = 0; i < _wheels.Length; i++)
        {
			_wheels[i].SlipForGenerateParticle = 0.4f;
			_wheels[i].TrailOffset.y = 0.05f;
			if (i % 2 == 0 || i == 0)
			{
				_wheels[i].TrailOffset.x = 0.1f;
			}
            else
            {
				_wheels[i].TrailOffset.x = -0.1f;
			}
		}
		EventTransferCarWheel?.Invoke(_wheels);
	}
}
