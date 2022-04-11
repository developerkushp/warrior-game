using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    public float _hurtTime = 1.5f;
    public bool _isTouching;
    private HealthManager _healthManager;
    [SerializeField] private float _damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (_reload)
        {
            _loadTime -= Time.deltaTime;
            if (_loadTime <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }*/
    
        if (_isTouching)
        {
            _hurtTime -= Time.deltaTime;
            if (_hurtTime <= 0)
            {
                _healthManager.HurtPlayer(_damage);
                _hurtTime = 1.5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(_damage);
           // _reload = true; 
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            _isTouching = true;
            //_anim.SetBool("isHurt", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            _isTouching = false;
            _hurtTime = 1.5f;
            //_anim.SetBool("isHurt", false);
        }
    }
}
