using System;
using TMPro;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2;

    [SerializeField]
    private TMP_Text _moneyLabel;
    
    private int _money = 0;

    private void Start()
    {
        _moneyLabel.text = $"У вас {_money}р.";
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")) * (_speed * Time.deltaTime);
    }

    public void AddMoney(int value)
    {
        _money += value;
        _moneyLabel.text = $"У вас {_money}р.";
    }
}