using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionRoad : MonoBehaviour {

    public List<GameObject> SpawnPoints;

    private BoxCollider ScoreCollider;
    private float scale = 10.08f;

    private void Awake()
    {
        ScoreCollider = GetComponent<BoxCollider>();
    }

    void Update () 
    {
        if (transform.position.z <= -scale){
            transform.Translate(Vector3.forward * (scale * 4));
            spawnEnemies();
        }	
	}

    void spawnEnemies()
    {
        if(!ScoreCollider.enabled){
            ScoreCollider.enabled = true;
        }
        
        foreach(GameObject enemy in SpawnPoints){
            enemy.SetActive(false);
        }

        GameObject spawnPoint = SpawnPoints[Random.Range(0,2)];
        spawnPoint.SetActive(true);
    }


}
