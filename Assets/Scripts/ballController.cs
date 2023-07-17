using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ballController : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private ParticleSystem margeParticle;
    [SerializeField] private gameManager _gameManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    bool birincil;
    [SerializeField] private bool defaultBall;
    private void Start()
    {
        numberText.text = number.ToString();

        if (defaultBall)
        {
            birincil = true;

        }
    }

    void stateChange()
    {
        birincil = true;
    }
    public void birincilStateChange()
    {
        Invoke("stateChange", 2f);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(number.ToString()) && birincil)
        {
            margeParticle.Play();
            collision.gameObject.SetActive(false);
            number += number;
            gameObject.tag = number.ToString();
            numberText.text = number.ToString();

            switch (number)
            {
                case 4:
                    _spriteRenderer.sprite = _gameManager.ballSprite[1];
                    break;
                case 8:
                    _spriteRenderer.sprite = _gameManager.ballSprite[2];
                    break;
                case 16:
                    _spriteRenderer.sprite = _gameManager.ballSprite[3];
                    break;
                case 32:
                    _spriteRenderer.sprite = _gameManager.ballSprite[4];
                    break;
                case 64:
                    _spriteRenderer.sprite = _gameManager.ballSprite[5];
                    break;
                case 128:
                    _spriteRenderer.sprite = _gameManager.ballSprite[6];
                    break;
                case 256:
                    _spriteRenderer.sprite = _gameManager.ballSprite[7];
                    break;
                case 512:
                    _spriteRenderer.sprite = _gameManager.ballSprite[8];
                    break;
                case 1024:
                    _spriteRenderer.sprite = _gameManager.ballSprite[8];
                    break;
                case 2048:
                    _spriteRenderer.sprite = _gameManager.ballSprite[8];
                    break;

            }
            if (_gameManager.haveBallQuest)
            {
                _gameManager.ballQuestController(number);
            }
            birincil = false;
            Invoke("stateChange", 2f);

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(number.ToString()) && birincil)
        {
            margeParticle.Play();
            collision.gameObject.SetActive(false);
            number += number;
            gameObject.tag = number.ToString();
            numberText.text = number.ToString();

            switch (number)
            {
                case 4:
                    _spriteRenderer.sprite = _gameManager.ballSprite[1];
                    break;
                case 8:
                    _spriteRenderer.sprite = _gameManager.ballSprite[2];
                    break;
                case 16:
                    _spriteRenderer.sprite = _gameManager.ballSprite[3];
                    break;
                case 32:
                    _spriteRenderer.sprite = _gameManager.ballSprite[4];
                    break;
                case 64:
                    _spriteRenderer.sprite = _gameManager.ballSprite[5];
                    break;
                case 128:
                    _spriteRenderer.sprite = _gameManager.ballSprite[6];
                    break;
                case 256:
                    _spriteRenderer.sprite = _gameManager.ballSprite[7];
                    break;
                case 512:
                    _spriteRenderer.sprite = _gameManager.ballSprite[8];
                    break;
                case 1024:
                    _spriteRenderer.sprite = _gameManager.ballSprite[8];
                    break;
                case 2048:
                    _spriteRenderer.sprite = _gameManager.ballSprite[8];
                    break;

            }

            if (_gameManager.haveBallQuest)
            {
                _gameManager.ballQuestController(number);
            }

            birincil = false;
            Invoke("stateChange", 2f);

        }
    }
}
