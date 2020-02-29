using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythm_controller : MonoBehaviour
{
	
	public int bpm = 132;

	float prevTime;
	float tempTime = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        print("Started");
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource song = GetComponent(typeof(AudioSource)) as AudioSource;
        float songDeltaTime = song.time - prevTime;
        tempTime += songDeltaTime;
        float hitTime = Mathf.Round((float)(60.0 / bpm) * 100) / 100;
        if(tempTime >= (hitTime * 4)) {
			print("Hit");
			tempTime = 0;
		}
		prevTime = song.time;
    }
    
    void spawnNote(int row) {
		float yPos = transform.GetChild(row).transform.position.y;
	}
}
