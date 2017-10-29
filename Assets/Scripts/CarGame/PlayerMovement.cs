using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rigidBody;
    private bool accelerateButtonPressed;


    public ButtonInteractive PowerButton;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

	void Update () 
    {
		if (!GameManager.instance.pausedGame) {
			move();
			Accelerate();
        }
	}

    private void Accelerate()
    {
        if(PowerButton.pressed && !accelerateButtonPressed){
            accelerateButtonPressed = true;
            GameManager.instance.setCarSpeed(5);
        }

        if(!PowerButton.pressed && accelerateButtonPressed){
            accelerateButtonPressed = false;
			GameManager.instance.setCarSpeed(-5);
        }
    }

	private void move()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			movePlayer(-2.5f);
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			movePlayer(2.5f);
		}
	}

    public void movePlayer(float xMovement)
    {
        SoundManager.instance.playAudioClip(1);
		rigidBody.MovePosition(new Vector3(xMovement,
											 transform.position.y,
											 transform.position.z));
    }

}
