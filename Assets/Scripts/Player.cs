using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 2f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] protected HealthManager _health;

    [SerializeField] Inventory _inventoryPrefab;
    private Inventory _inventory;

    private Vector2 _moveDirection;
    private Animator _anim;

    private float _fightTime = 0.5f;
    private float _fightCounter = 0.5f;
    private bool _isFighting;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _inventory = Instantiate(_inventoryPrefab);
    }

    void Update()
    {
        ProcessInputs();
        UpdateState();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        _rb.velocity = new Vector2(_moveDirection.x * _speed, _moveDirection.y * _speed); 
        if (_isFighting)
        {
            _rb.velocity = Vector2.zero;
        }
    }

    void UpdateState()
    {
        if (Mathf.Approximately(_moveDirection.x, 0) &&
        Mathf.Approximately(_moveDirection.y, 0))
        {
            _anim.SetBool("isWalking", false);
        }
        else
        {
            _anim.SetBool("isWalking", true);
        }
        _anim.SetFloat("xDir", _moveDirection.x);
        _anim.SetFloat("yDir", _moveDirection.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            _anim.SetFloat("lastXDir", Input.GetAxisRaw("Horizontal"));
            _anim.SetFloat("lastYDir", Input.GetAxisRaw("Vertical"));
        }

        if (_isFighting)
        {
            _fightCounter -= Time.deltaTime;
            if (_fightCounter <= 0)
            {
                _anim.SetBool("isFighting", false);
                _isFighting = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            _fightCounter = _fightTime;
            _anim.SetBool("isFighting", true);
            _isFighting = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            ItemData hitObject = collision.gameObject.GetComponent<Consumable>().Item;
            if (hitObject != null)
            {
                print("Hit: " + hitObject.ObjectName);
                bool shouldDisappear = false;
                switch (hitObject.Type)
                {
                    case ItemData.ItemType.Coin:
                        shouldDisappear = _inventory.AddItem(hitObject);
                        break;
                    case ItemData.ItemType.Health:
                        shouldDisappear = AdjustHitPoints(hitObject.Quantity);
                        break;
                }
                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    public bool AdjustHitPoints(float amount)
    {
        if (_health._health < _health._maxHealth)
        {
            _health._health = _health._health + (amount * 5);
            print("Adjusted HP by: " + (amount * 5) + ". New value: " +
            _health._health);
            return true;
        }
        return false;
    }

    /**public void AdjustHitPoints(float amount)
    {
        _health._health = _health._health + (amount*5);
        print("Adjusted hitpoints by: " + (amount*5) + ". New value: " + _health._health);
    }**/
}
