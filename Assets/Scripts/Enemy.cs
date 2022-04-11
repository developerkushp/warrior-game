using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _maxRange = 3f;
    [SerializeField] private float _minRange = 0.4f;

    private Animator _anim;
    private Transform _target;

    public Transform startingPosition;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _target = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        if (Vector3.Distance(_target.position, transform.position) <= _maxRange && Vector3.Distance(_target.position, transform.position) >= _minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(_target.position, transform.position) >= _maxRange)
        {
            GoHome();
        }
    }

    public void FollowPlayer()
    {
        _anim.SetBool("isWalking", true);
        _anim.SetFloat("xDir", (_target.position.x - transform.position.x));
        _anim.SetFloat("yDir", (_target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void GoHome()
    {
        _anim.SetFloat("xDir", (startingPosition.position.x - transform.position.x));
        _anim.SetFloat("yDir", (startingPosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, startingPosition.position, _speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, startingPosition.position) == 0)
        {
            _anim.SetBool("isWalking", false);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitZone")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }*/
}
