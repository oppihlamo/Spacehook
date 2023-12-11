using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
	public int targetFrameRate = 60;

	private void Start()
	{
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = targetFrameRate;
	}
}
