using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note_controller : MonoBehaviour
{
    public float moveSpeed = 100;
    public KeyCode key = KeyCode.A;
    
    float tempTime;
    Vector3 startPos;
    Vector3 targetPos = Vector3.zero;
    float timeToReachTarget;
    
    
    // Start is called before the first frame update
    void Start()
    {
		// Set Label to Key
        transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = key.ToString();
        
        // Set start position
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
		
		tempTime += Time.deltaTime/timeToReachTarget;
		transform.localPosition = Vector3.Lerp(startPos, targetPos, tempTime);
		
		// Move Left
        //transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        
        // Destroy Itself if off the left side of the screen
        if(transform.localPosition.x < -300) {
			Destroy(gameObject);
		}
		
		// Destroy Object if User Hits Note
		if(transform.localPosition.x < 50 && transform.localPosition.x > -50 && Input.GetKeyDown(key)) {
			Destroy(gameObject);
		}
    }
    
    public void SetTarget(Vector3 target, float time) {
            tempTime = 0;
            startPos = transform.localPosition;
            timeToReachTarget = time;
            targetPos = target; 
     }
}
