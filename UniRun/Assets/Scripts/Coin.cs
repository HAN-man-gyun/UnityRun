using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class Coin : MonoBehaviour
{
    public AudioClip coinClip;
    private AudioSource coinAudio;
    private SpriteRenderer coinSprite;

    // Start is called before the first frame update
    void Start()
    {
        coinAudio = GetComponent<AudioSource>();
        coinSprite = GetComponent<SpriteRenderer>();
        Function.Assert(coinAudio != null);
        coinAudio.clip = coinClip;
        coinSprite.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            
            coinAudio.Play();
            GameManager.instance.AddScore(1);
            //Destroy(gameObject);
            coinSprite.enabled = false;
        }
    }
}
