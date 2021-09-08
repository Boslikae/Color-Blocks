using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController
{
	public class GameController : MonoBehaviour
	{
		public static GameObject[] boxes;
        public static GameObject box;
        public static int i = 0;
        public static int Ln;

		public void Awake()
		{
			boxes = GameObject.FindGameObjectsWithTag("Box");
            Ln = boxes.Length;
		}

    	void Start()
    	{
            box = boxes[i];

            var script = box.GetComponent<Box>();
            var light = box.GetComponent<Light>();

            var rg = box.AddComponent<Rigidbody>();
            rg.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
           
            light.enabled = true;
            script.enabled = true;
    	}

    	void FixedUpdate()
    	{
            if(Input.GetKeyUp(KeyCode.Space))
            {               
                BoxController();
            }
    	}

        public void BoxController()
        {
            var prevScript = box.GetComponent<Box>();
            var prevLight = box.GetComponent<Light>();
            var prevRg = box.GetComponent<Rigidbody>();
            Destroy(prevRg);
                
            prevLight.enabled = false;
            prevScript.enabled = false;

            if(i==Ln)
            {
                i = 0;
            }

            box = boxes[i];
            i++;

            var rg = box.AddComponent<Rigidbody>();
            rg.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                
            var script = box.GetComponent<Box>();
            var light = box.GetComponent<Light>();

            light.enabled = true;
            script.enabled = true;
        }


	}

}