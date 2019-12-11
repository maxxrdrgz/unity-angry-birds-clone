using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private AudioSource audioSource;
    public float health = 150f;
    public Sprite spriteShownWhenHurt;
    private float changeSpriteHealth;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        changeSpriteHealth = health - 30f;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Rigidbody2D>() == null){
            return;
        }

        if(other.gameObject.tag == "Bird"){
            audioSource.Play();
            Destroy(gameObject);
        }else{
            float damage = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10f;

            health -= damage;

            if(damage >= 10){
                audioSource.Play();
            }

            if(health < changeSpriteHealth){
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteShownWhenHurt;
            }

            if(health <= 0){
                Destroy(gameObject);
            }
        }
    }
}
