using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControls : MonoBehaviour {

    [SerializeField]
    AudioSource music;
    float musicLength;

    float positionVal;

    [SerializeField]
    Slider sliderMusic;

    public bool isPlaying;



	void Start () {
        musicLength = music.GetComponent<AudioSource>().clip.length;
        positionVal = 0;
        isPlaying = true;
	}
	
	void Update () {

        sliderMusic.value = music.time*100/musicLength;

	}

    public void PlayPause()
    {
        if (isPlaying)
        {
            music.Pause();
            isPlaying = false;
        }
        else
        {
            music.Play();
            isPlaying = true;
        }
    }

    public void ChangeClipPosition()
    {
        positionVal = sliderMusic.value;
        music.time = positionVal * musicLength / 100;

    }
}
