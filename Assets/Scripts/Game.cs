using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverSreen _gameOverSreen;
    [SerializeField] private Transform _floorContainer;
    [SerializeField] private Transform _backgroundContainer;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverSreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
        _player.EnvironmentChange += OnEnvironmentChange;
        _player.SkinChange += OnSkinChanged;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverSreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
        _player.EnvironmentChange -= OnEnvironmentChange;
        _player.SkinChange -= OnSkinChanged;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _startScreen.DisplayMoney(_player.Money);
    }

    private void SetEnvironment(Environment environment)
    {
        Instantiate(environment.Floor, _floorContainer);
        Instantiate(environment.Background, _backgroundContainer);
        _pipeGenerator.SetNewPipe(environment.Pipe);
    }

    private void SetSkin(Skin skin)
    {
        Instantiate(skin.Renderer.gameObject, _bird.transform);
    }

    private void OnEnvironmentChange(Environment environment)
    {
        var previousFloor = _floorContainer.GetComponentsInChildren<Floor>();
        var previousBackground = _backgroundContainer.GetComponentsInChildren<Background>();

        if (previousFloor.Length > 0)
            Destroy(previousFloor[0].gameObject);

        if (previousBackground.Length > 0)
            Destroy(previousBackground[0].gameObject);

        SetEnvironment(environment);
        _startScreen.DisplayMoney(_player.Money);
    }

    private void OnSkinChanged(Skin skin)
    {
        var previousSkin = _bird.GetComponentsInChildren<SpriteRenderer>();

        if (previousSkin.Length > 0)
            Destroy(previousSkin[0].gameObject);

        SetSkin(skin);
        _startScreen.DisplayMoney(_player.Money);
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverSreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        _bird.ResetBird();
        _pipeGenerator.ResetPool();
        Time.timeScale = 1;
    }

    private void OnGameOver()
    {
        _player.AddMoney(_bird.Score);
        Time.timeScale = 0;
        _gameOverSreen.Open();
        _startScreen.DisplayMoney(_player.Money);
    }
}
