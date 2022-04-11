using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealthManager enemyHealthManager;
            enemyHealthManager = other.gameObject.GetComponent<EnemyHealthManager>();
            enemyHealthManager.HurtEnemy(_damage);
        }
    }
}
