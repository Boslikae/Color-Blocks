using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTask : MonoBehaviour
{
	public string _taskBoxColor;
	public static GameObject[] boxes;

    void Awake()
    {
        boxes = GameObject.FindGameObjectsWithTag("Box");

		foreach(GameObject bx in boxes)
		{
			var x = Mathf.Round(transform.position.x / bx.transform.position.x);		
			if(_taskBoxColor == bx.name & x==1)
			{			
				bx.GetComponent<Box>().check = true;
			}			
		}
    }

}

