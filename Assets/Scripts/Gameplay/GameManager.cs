using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // our player
    [SerializeField] private PlayerController _player;
    // start position for our player
    [SerializeField] private Transform _startPosition = null;

    [SerializeField] private Camera _camera;

    [Header("UI")]
    [SerializeField] private GameObject _gameplayUI = null;
    [SerializeField] private GameObject _endGameUI = null;
    [SerializeField] private GameObject _pauseUI = null;

    // our created player
    private GameObject _currentPlayer;

    private void OnEnable()
    {
        FinishGame.OnFinishGame += EndGame;
        TouchDetection.OnSetPause += SetPause;
        TouchDetection.OnRestartGame += RestartGame;
        TouchDetection.OnExitGame += Exit;
    }

    private void OnDisable()
    {
        FinishGame.OnFinishGame -= EndGame;
        TouchDetection.OnSetPause -= SetPause;
        TouchDetection.OnRestartGame -= RestartGame;
        TouchDetection.OnExitGame -= Exit;
    }

    private void Awake()
    {
        StartGame();
    }

    private void StartGame()
    {
        if (_endGameUI.activeSelf)
            _endGameUI.SetActive(false);

        if (_pauseUI.activeSelf)
            _pauseUI.SetActive(false);

        _gameplayUI.SetActive(true);

        Time.timeScale = 1.0f;

        _currentPlayer = Instantiate(_player.transform.gameObject, _startPosition.position, _startPosition.rotation);

        _camera.GetComponent<CameraFollow>().SetPlayer(_currentPlayer);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        Destroy(_currentPlayer);

        StartGame();
    }

    private void EndGame()
    {
        Time.timeScale = 0.0f;

        if (_gameplayUI.activeSelf)
            _gameplayUI.SetActive(false);

        _endGameUI.SetActive(true);
    }

    private void SetPause(bool isPause)
    {
        if (isPause)
        {
            Time.timeScale = 0.0f;

            if (_gameplayUI.activeSelf)
                _gameplayUI.SetActive(false);

            if (_endGameUI.activeSelf)
                _endGameUI.SetActive(false);

            _pauseUI.SetActive(true);
        }
        else
        {
            _pauseUI.SetActive(false);

            _gameplayUI.SetActive(true);

            Time.timeScale = 1.0f;
        }
    }
}
