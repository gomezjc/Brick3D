using UnityEngine;

public class Score : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            GameManager.instance.addScore(1);
        }
    }
}
