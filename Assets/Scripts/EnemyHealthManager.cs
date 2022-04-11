using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float _maxHealth = 25f;
    public float _health = 25f;

    private bool _isHurt;
    [SerializeField] private float _flash = 0f;
    private float _flashTime = 0f;
    private SpriteRenderer _enemySprite;

    // Start is called before the first frame update
    void Start()
    {
        _enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isHurt)
        {
            if (_flashTime > _flash * 0.99f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 0f);
            }
            else if (_flashTime > _flash * 0.87f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 1f);
            }
            else if (_flashTime > _flash * 0.75f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 0f);
            }
            else if (_flashTime > _flash * 0.63f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 1f);
            }
            else if (_flashTime > _flash * 0.51f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 0f);
            }
            else if (_flashTime > _flash * 0.39f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 1f);
            }
            else if (_flashTime > _flash * 0.27f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 0f);
            }
            else if (_flashTime > _flash * 0.15f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 1f);
            }
            else if (_flashTime > 0f)
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 0f);
            }
            else
            {
                _enemySprite.color = new Color(_enemySprite.color.r, _enemySprite.color.g, _enemySprite.color.b, 1f);
                _isHurt = false;
            }
            _flashTime -= Time.deltaTime;
        }
    }

    public void HurtEnemy(float damage)
    {
        _health -= damage;
        _isHurt = true;
        _flashTime = _flash;

        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
