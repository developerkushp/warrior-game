using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float _maxHealth = 100f;
    public float _health = 70f;

    private bool _isHurt;
    [SerializeField] private float _flash = 0f;
    private float _flashTime = 0f;
    private SpriteRenderer _playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isHurt)
        {
            if (_flashTime > _flash * 0.99f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, 1, 1, 0f);
            }
            else if (_flashTime > _flash * 0.75f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, 0, 0, 1f);
            }
            else if (_flashTime > _flash * 0.51f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, 1, 1, 0f);
            }
            else if (_flashTime > _flash * 0.27f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, 0, 0, 1f);
            }
            else if (_flashTime > 0f)
            {
                _playerSprite.color = new Color(_playerSprite.color.r, 1, 1, 0f);
            }
            else
            {
                _playerSprite.color = new Color(_playerSprite.color.r, 1, 1, 1f);
                _isHurt = false;
            }
            _flashTime -= Time.deltaTime;
        }
    } 

    public void HurtPlayer(float damage)
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
