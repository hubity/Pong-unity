using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

    }

    public void Init(bool isRightPaddle)
    {
        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            // place paddle on the right os screen
            pos = new Vector2(manager.topRight.x, 0);

            pos -= Vector2.right * transform.localScale.x; // move a bit to the left
        } else
        {
            pos = new Vector2(manager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; // move a bit de right
        }

        //Update this paddle position
        transform.position = pos;
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
