using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
	public static int count = 0;
	public static GameObject[] boxes;
	public static int Ln;
	public static bool victory;
	public static GameObject VictoryMenu;
	public static bool playOnce;

	AudioSource m_AudioSource;

	void Awake()
	{
		VictoryMenu = GameObject.Find("VictoryMenu");
		VictoryMenu.SetActive(false);
	}

    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("Box");
        Ln = boxes.Length;       

        m_AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        CheckGame();
        
        if(victory == true)
        {    	      	
        	if(playOnce == false)
        	{
        		PlaySound();
        		VictoryMenu.SetActive(true);
        	}

        	playOnce = true;			
        }
    }

    public void CheckGame()
    {
    	foreach(GameObject bx in boxes)
        {
        	var Ch = bx.GetComponent<Box>();
        	var check = Ch.check;
        	if(check == true)
        	{
        		count = count + 1;
        	}
        }

        if(count == Ln)
        {
        	victory = true;
        }
        else
        {
        	victory = false;
        }

        count = 0;
    }

    public void PlaySound()
    {
    	if (!m_AudioSource.isPlaying)
    	{
    		m_AudioSource.Play();
    	}
    }

}
