using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour
{
    [SerializeField] private gameManager _gameManager;
    public void powerBox()
    {
        _gameManager.boxEffect(transform.position);
        gameObject.SetActive(false);
    }
}
