using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager _healthManager;

    [SerializeField]private Slider _healthBar;
    [SerializeField] private Text _hp;

    // Start is called before the first frame update
    void Start()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.maxValue = _healthManager._maxHealth;
        _healthBar.value = _healthManager._health;
        _hp.text = "HP: " + _healthManager._health;
    }
}
