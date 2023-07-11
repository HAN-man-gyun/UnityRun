using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private GameObject[] obstacle;
    private bool stepped = false;
    public GameObject coinPrefab;
    public GameObject[] coins;
    private void OnEnable()
    {
        stepped = false;
        for (int i = 0; i < coins.Length; i++)
        {


            int isActive = Random.Range(0, 10);
            Debug.LogFormat("값은 {0}이다.", isActive);
            if (isActive >= 6)
            {
                 coins[i].SetActive(true);
            }
            else
            {
                 coins[i].SetActive(false);
            }
        }

     
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Player") && stepped == false)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }


}
