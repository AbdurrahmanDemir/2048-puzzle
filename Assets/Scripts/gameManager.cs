using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

[Serializable]
public class quest
{    public Sprite questImage;
    public int questNumber;
    public string questType;
    public GameObject questComplete;
}

[Serializable]
public class questUI
{
    public GameObject quest;
    public Image questImage;
    public TextMeshProUGUI questNumber;    
    public GameObject questComplete;
}
public class gameManager : MonoBehaviour
{



    [Header("-----LEVEL SETTINGS")]
    public Sprite[] ballSprite;
    public GameObject[] ball;
    public TextMeshProUGUI remainingBallText;
    int remainingBall;
    int poolIndex;

    [Header("----OTHER SETTINGS")]
    public ParticleSystem bombEffects;
    public ParticleSystem[] boxEffects;
    int boxEffectIndex;
    public GameObject winPanel;
    public GameObject lostPanel;
    [Header("----BALL SETTINGS")]
    public GameObject ballShooter;
    public GameObject ballSocket;
    public GameObject nextBall;
    GameObject selectedBall;

    [Header("----QUEST SETTINGS")]
    public List<questUI> _questUI;
    public List<quest> _quest;
    int ballValue, boxValue, totalQuest;
    bool haveBoxQuest;
    public bool haveBallQuest;


    private void Start()
    {
        totalQuest = _quest.Count;
        boxEffectIndex = 0;
        ballCreat(true);
        remainingBall = ball.Length;

        for (int i = 0; i < _quest.Count; i++)
        {
            _questUI[i].quest.SetActive(true);
            _questUI[i].questImage.sprite = _quest[i].questImage;
            _questUI[i].questNumber.text = _quest[i].questNumber.ToString();

            if (_quest[i].questType=="Ball")
            {
                haveBallQuest = true;
                ballValue = _quest[i].questNumber;
            }else if (_quest[i].questType == "Box")
            {
                haveBoxQuest= true;
                boxValue= _quest[i].questNumber;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


            if (hit.collider!=null)
            {
                if (hit.collider.gameObject.CompareTag("gameBoard"))
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    ballShooter.transform.position = Vector2.MoveTowards(ballShooter.transform.position, new Vector2 (mousePos.x,ballShooter.transform.position.y),30*Time.deltaTime);
                        
                }
            }

            Debug.DrawRay(ray.origin,ray.direction*10,Color.green);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            selectedBall.transform.parent = null;
            selectedBall.GetComponent<ballController>().birincilStateChange();
            ballCreat(false);

        }
    }
    public void ballCreat(bool firstCreat)
    {

        if (firstCreat)
        {
            ball[poolIndex].transform.SetParent(ballShooter.transform);
            ball[poolIndex].transform.position = ballSocket.transform.position;
            ball[poolIndex].SetActive(true);
            selectedBall = ball[poolIndex];

            poolIndex++;

            ball[poolIndex].transform.position = nextBall.transform.position;
            ball[poolIndex].SetActive(true);
            remainingBallText.text = remainingBall.ToString();
        }
        else
        {
            if (ball.Length!=0)
            {
                ball[poolIndex].transform.SetParent(ballShooter.transform);
                ball[poolIndex].transform.position = ballSocket.transform.position;
                ball[poolIndex].SetActive(true);
                selectedBall = ball[poolIndex];

                remainingBall--;
                remainingBallText.text=remainingBall.ToString();

                if (poolIndex!=ball.Length-1)
                {
                    poolIndex++;
                    ball[poolIndex].transform.position = nextBall.transform.position;
                    ball[poolIndex].SetActive(true);
                }
                
            }
            if (totalQuest == 0)
            {
                youWin();
            }
            //else
            //{
            //    youLost();
            //}
        }
        
    }

    public void bombEffect(Vector2 pos)
    {
        bombEffects.gameObject.transform.position=pos;
        bombEffects.gameObject.SetActive(true);
        bombEffects.Play();
    }
    public void boxEffect(Vector2 pos)
    {
        boxEffects[boxEffectIndex].gameObject.transform.position = pos;
        boxEffects[boxEffectIndex].gameObject.SetActive(true);
        bombEffects.Play();

        if (haveBoxQuest)
        {
            boxValue--;
            if (boxValue==0)
            {
                _questUI[1].questComplete.SetActive(true);
                totalQuest--;
                if (totalQuest == 0)
                {
                    youWin();
                }
            }
           
        }
        
        if (boxEffectIndex==boxEffects.Length-1)
        {
            boxEffectIndex = 0;
        }
        else
        {
            boxEffectIndex++;
        }
    }

    public void ballQuestController(int number)
    {
        if (number==ballValue)
        {
            _questUI[0].questComplete.SetActive(true);

            totalQuest--;
            if (totalQuest == 0)
            {
                youWin();
            }
        }
    }
    public void youWin()
    {
        winPanel.SetActive(true);
    }
    public void youLost()
    {
        lostPanel.SetActive(true);
    }

    public void nextLevel()
    {
        
        levelLoader.instance.NextLevel();
    }
    public void replayLevel()
    {
        levelLoader.instance.GetLevel();
    }
}
