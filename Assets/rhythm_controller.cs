using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythm_controller : MonoBehaviour
{
	public enum KeySet {One, Two};
	public enum Difficulty {Easy, Intermediate, Hard};
	
	public GameObject note;
	public int bpm = 132;
	public int notesToWin = 30;
	public Difficulty difficulty;
	public KeySet keyset;
	public AudioClip noteHitSound;
	public bool bounceDifficulty;
	public Difficulty[] bounceDistribution;
	public float bounceChance = 0.01f; // Out of 100
	

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
		if(bounceDifficulty && Random.Range(1.0f, 100.0f) <= bounceChance) {
			difficulty = bounceDistribution[Random.Range(0, bounceDistribution.Length)];
			//bounceChance  = 100 - bounceChance;
		}
		
        AudioSource song = GetComponent(typeof(AudioSource)) as AudioSource;
        float songDeltaTime = song.time - prevTime;
        tempTime += songDeltaTime;
        float hitTime = Mathf.Round((float)(60.0 / bpm) * 100) / 100;
        float interval = hitTime;
        if(difficulty == Difficulty.Easy) {
			interval *= 4;
		} else if(difficulty == Difficulty.Intermediate) {
			interval *= 2;
		} else if(difficulty == Difficulty.Hard) {
			interval *= 1;
		}
        
        if(tempTime >= interval) {
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
		
		if(keyset == KeySet.One) {
			if(row == 0) {
				newNoteScript.key = KeyCode.A;
			} else if (row == 1) {
				newNoteScript.key = KeyCode.S;
			} else if (row == 2) {
				newNoteScript.key = KeyCode.D;
			}
		} else if(keyset == KeySet.Two) {
			bool rand = Random.value > 0.5f;
			if(row == 0) {
				newNoteScript.key = rand ? KeyCode.A : KeyCode.Q;
			} else if (row == 1) {
				newNoteScript.key = rand ? KeyCode.S : KeyCode.W;
			} else if (row == 2) {
				newNoteScript.key = rand ? KeyCode.D : KeyCode.E;
			}
		}
	}
	
	void noteHit() {
		transform.GetChild(3).GetComponent<UnityEngine.UI.Slider>().value += (float)1 / notesToWin;
		GetComponents<AudioSource>()[1].PlayOneShot(noteHitSound, 1.0f);
		if(transform.GetChild(3).GetComponent<UnityEngine.UI.Slider>().value >= 1) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("win_scene");
		}
	}
	
	void noteMissed() {
		transform.GetChild(3).GetComponent<UnityEngine.UI.Slider>().value -= (float)1 / notesToWin;
		if(transform.GetChild(3).GetComponent<UnityEngine.UI.Slider>().value <= 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("lose_scene");
		}
	}
}
