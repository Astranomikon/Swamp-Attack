using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction : Ammo
{
    [SerializeField] private float _range;

    private Vector3 _targetPositoin;

    private void Start()
    {
        _targetPositoin = new Vector3(transform.position.x - _range, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPositoin, Speed * Time.deltaTime);

        if (transform.position == _targetPositoin ) 
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
        }
    }
}
