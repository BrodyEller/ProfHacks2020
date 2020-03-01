using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythm_controller : MonoBehaviour
{
	public GameObject note;
	public int bpm = 132;
	public int notesToWin = 30;

	float prevTime;
	float tempTime = 0;
	
    // Start is called before the first frame update
//    void Start()
//    {
//        print("Started");
//    }

    // Update is called once per frame
    void Update()
    {
        AudioSource song = GetComponent(typeof(AudioSource)) as AudioSource;
        float songDeltaTime = song.time - prevTime;
        tempTime += songDeltaTime;
        float hitTime = Mathf.Round((float)(60.0 / bpm) * 100) / 100;
        if(tempTime >= (hitTime * 4)) {
			//print("Hit");
			spawnNote(Random.Range(0, 3));
			tempTime = 0;
		}
		prevTime = song.time;
		
		
		transform.GetChild(3).GetComponent<UnityEngine.UI.Slider>().value -= (float)1 / (notesToWin * 5) * Time.deltaTime;
    }
    
    void spawnNote(int row) {
		float hitTime = Mathf.Round((float)(60.0 / bpm) * 100) / 100;
		
		GameObject newNote = Instantiate(note, transform.position, transform.rotation);
		newNote.transform.SetParent(transform.GetChild(row));
		newNote.transform.localPosition = new Vector3(1600, 0, 0);
		
		note_controller newNoteScript = newNote.GetComponent<note_controller>();
		newNoteScript.SetTarget(new Vector3(-1600, 0, 0), hitTime * 4 * 8);
		newNoteScript.noteHit.AddListener(noteHit);
		newNoteScript.noteMissed.AddListener(noteMissed);
		newNoteScript.wrongNotePressed.AddListener(noteMissed);
		
				
		if(row == 0) {
			newNoteScript.key = KeyCode.A;
		} else if (row == 1) {
			newNoteScript.key = KeyCode.S;
		} else if (row == 2) {
			newNoteScript.key = KeyCode.D;
		}
	}
	
	void noteHit() {
		transform.GetChild(3).GetComponent<UnityEngine.UI.Slider>().value += (float)1 / notesToWin;
	}
	
	void noteMissed() {
		transform.GetChild(3).GetComponent<UnityEngine.UI.Slider>().value -= (float)1 / notesToWin;
	}
}
