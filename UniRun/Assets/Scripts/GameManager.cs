using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public TMP_Text scoreText;  //Text Mesh Pro 컴포넌트 쓴경우
    public GameObject gameoverUi;
    // Start is called before the first frame update

    private int score = 0;

    private void Awake()
    {
        if(instance.IsValid() == false)
        {
            instance = this;
        }
        else
        {
            Function.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
/*        List<int> intList = new List<int>();
        intList.Add(0);
        Debug.LogFormat("intList가 유효한지? (존재하는지?) : {0}", intList.IsValid());*/
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true && Input.GetMouseButtonDown(0))
        {
            //Function.LoadScene("SampleScene");
            Function.LoadScene(Function.GetActiveSceneName());
        }
    }

    public void AddScore(int newScore)
    {
        if(isGameOver == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }

    
    
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUi.SetActive(true);
    }
}
