using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
  public class PlayerScore : MonoBehaviour
  {
    [SerializeField] private List<GameObject> scorePoint;
    [SerializeField] private TMP_Text scoreText;
    private int _score;

    private void Start()
    {
      _score = 0;
      UpdateScoreText();
    }

    public void AddScore()
    {
      _score++;
      UpdateScoreText();
      if (_score == scorePoint.Count)
      {
        Finish();
      }
    }

    private void UpdateScoreText()
    {
      scoreText.text = "Очки: " + _score.ToString(); // Обновляем текст
    }

    private void Finish()
    {
      SceneManager.LoadScene("Final");
    }
  }
}
