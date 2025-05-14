using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")) * (_speed * Time.deltaTime);
    }
}