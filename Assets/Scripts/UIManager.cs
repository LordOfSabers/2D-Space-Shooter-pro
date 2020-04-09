using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _livesSprite;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    private bool _gameOver = false;
    [SerializeField]
    private GameMaster _gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: 000";
        _gameOverText.gameObject.SetActive(false);
       /* 
        _gameMaster = GameObject.Find("Game_Master").GetComponent<GameMaster>();
        if(_gameMaster = null)
        {
            Debug.LogError("GameMaster is NULL.");
        }
       */
    }



    public void GameOverStart(int Score)
    {
        Debug.Log("Debug:UIManager::GameOverStart called");
        _gameMaster.Gameover();
        _gameOver = true;
        StartCoroutine(GameOverRoutine(Score));
        _restartText.gameObject.SetActive(true);
    }
    IEnumerator GameOverRoutine(int FinalScore)
    {
        while (_gameOver == true)
        {
            _gameOverText.text = "Game Over! Final Score: " + FinalScore;
            _gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    public void UpdateLivesUI(int currentLives)
    {
        _livesImage.sprite = _livesSprite[currentLives];
    }
}
