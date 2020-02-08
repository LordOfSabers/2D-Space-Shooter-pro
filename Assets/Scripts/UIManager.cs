using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: 000";
    }

    // Update is called once per frame
    void Update()
    {
       
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
