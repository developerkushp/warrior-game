using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ConfineCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vCam1;
    [SerializeField] private GameObject _player;

    private CinemachineConfiner _confiner;
    private CinemachineComponentBase _myCamera;

    private void Start()
    {
        _myCamera = _vCam1.GetCinemachineComponent<CinemachineComponentBase>();
        _confiner = _vCam1.GetComponent<CinemachineConfiner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 playerPos = _player.transform.position;
            Vector3 camPos = _vCam1.transform.position;

            if (_player)
            {
                _confiner.InvalidatePathCache();
                _confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Boundary2").GetComponent<Collider2D>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 playerPos = _player.transform.position;
            Vector3 camPos = _vCam1.transform.position;

            if (_player)
            {
                _confiner.InvalidatePathCache();
                _confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Boundary1").GetComponent<Collider2D>();
            }
        }
    }
}

