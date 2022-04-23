 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    [SerializeField] private Transform _playerStartPos;
    [SerializeField] private Player _player;
    [SerializeField] private bool _holdingPlayer;

    private Camera _cam;

    public static PlayerLauncher instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        if (_player == null)
            return;
        

        if (InputDown() && !_player.launching)
        {
            Vector3 touchWorldPosition;

            if (Input.touchCount > 0)
            {
                touchWorldPosition = _cam.ScreenToWorldPoint(Input.touches[0].position);
            }
            else
            {
                touchWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            }

            touchWorldPosition.z = 0;

            if (Vector3.Distance(touchWorldPosition, _player.transform.position) <= 3.0f)
            {
                _holdingPlayer = true;
            }
        }

        if (InputUp() && _holdingPlayer)
        {
            _holdingPlayer = false;
            _player.Launch(_playerStartPos.position - _player.transform.position);
        }

        if (_holdingPlayer && !_player.launching)
        {
            Vector3 newPos;

            if (Input.touchCount > 0)
            {
                newPos = _cam.ScreenToWorldPoint(Input.touches[0].position);
            }
            else
            {
                newPos = _cam.ScreenToWorldPoint(Input.mousePosition);
            }

            newPos.z = 0;
            _player.transform.position = newPos;
        }
        
    }

    // parmak ya da fare tıklaması kontrolü (basıldıysa)
    bool InputDown()
    {
        // input kontrolü yap
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began )
        {
            return true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        
        return false;
    }
    
    // parmak ya da fare tıklaması kontrolü (çekildiyse)
    bool InputUp() 
    {
        // input kontrolü yap
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended )
        {
            return true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            return true;
        }
        
        return false;
    }

    public void SetNewPlayer(GameObject playerPrefab)
    {
        _player = Instantiate(playerPrefab, _playerStartPos.position, Quaternion.identity).GetComponent<Player>();
        CameraController.instance.SetPlayer(_player);
    }
}
