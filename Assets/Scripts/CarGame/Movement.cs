using UnityEngine;

public class Movement : MonoBehaviour {
    
    private void Update()
    {
        if(!GameManager.instance.gameOver && !GameManager.instance.pausedGame){
			moveRoad();
        }
    }

    private void moveRoad()
    {
		float movement = transform.position.z - GameManager.instance.speedCar * Time.deltaTime;
		transform.position = new Vector3(transform.position.x,
										 transform.position.y,
										 movement);
    }


}
