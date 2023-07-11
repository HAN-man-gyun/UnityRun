using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public TMP_Text scoreText;  //Text Mesh Pro ������Ʈ �����
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
            Function.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
/*        List<int> intList = new List<int>();
        intList.Add(0);
        Debug.LogFormat("intList�� ��ȿ����? (�����ϴ���?) : {0}", intList.IsValid());*/
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
