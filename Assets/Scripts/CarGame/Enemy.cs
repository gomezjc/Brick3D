using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            SoundManager.instance.playAudioClip(0);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.instance.GameOver();
            Instantiate(explosionEffect,transform.position,Quaternion.identity);
        }
    }
}
