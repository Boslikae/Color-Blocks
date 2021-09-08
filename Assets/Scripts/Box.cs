using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
	public GameObject _box;
	public GameObject[] taskBoxes;
	public float _speed;
	public bool check;
	public float taskPosition;

	AudioSource m_AudioSource;

    void Start()
    {
    	taskBoxes = GameObject.FindGameObjectsWithTag("TaskBox");
    	foreach(GameObject tbx in taskBoxes)
    	{
    		var color = tbx.GetComponent<CheckTask>()._taskBoxColor;
    		if(_box.name == color)
    		{
    			taskPosition = tbx.transform.position.x;
  	 		}   		
    	}

    	m_AudioSource = GetComponent<AudioSource> ();
    }

    void FixedUpdate()
    {
    	Move();
    }

    public void Move()
    {
    	if(Input.GetKey(KeyCode.RightArrow)){
    		PlaySound();
        	_box.transform.position += _box.transform.right * _speed * Time.deltaTime;       	
        	Check();
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
        	PlaySound();
        	_box.transform.position -= _box.transform.right * _speed * Time.deltaTime;        	
        	Check();
        }
        if(Input.GetKey(KeyCode.UpArrow)){
        	PlaySound();
        	_box.transform.position += _box.transform.up * _speed * Time.deltaTime;        	
        	Check();
        }
        if(Input.GetKey(KeyCode.DownArrow)){
        	PlaySound();
        	_box.transform.position -= _box.transform.up * _speed * Time.deltaTime;       	
        	Check();
        }
    }

    public void Check()
    {
    	var x = Mathf.Round(_box.transform.position.x / taskPosition);
    	if(x == 1)
    	{
    		check = true;
    	}
    	else
    	{
    		check = false;
    	}
    }

    public void PlaySound()
    {
    	if (!m_AudioSource.isPlaying)
    	{
    		m_AudioSource.Play();
    	}
    }
}
