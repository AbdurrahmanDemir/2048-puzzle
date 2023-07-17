using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bombController : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private gameManager _gameManager;

    List<Collider2D> colliders = new List<Collider2D>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(number.ToString()))
        {
            powerBomb();
        }
    }
    public void powerBomb()
    {
        var contactFilter = new ContactFilter2D
        {
            useTriggers = true,
        };


        Physics2D.OverlapBox(transform.position, transform.localScale * 7, 25f, contactFilter, colliders);

        _gameManager.bombEffect(transform.position);
        gameObject.SetActive(false);

        foreach (var item in colliders)
        {
            if (item.gameObject.CompareTag("box"))
            {
                item.GetComponent<boxController>().powerBox();
                Debug.Log("çalýþtý");
            }
            else
            {
                item.gameObject.GetComponent<Rigidbody2D>().AddForce(90 * new Vector2(0, 6), ForceMode2D.Force);
            }
        }
    }
}
