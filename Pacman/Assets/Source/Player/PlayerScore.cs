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

    [SerializeField] private int scorePerHit;
    private int _hitCount=1;

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

    public void Attack()
    {
      _score += scorePerHit * _hitCount;
      _hitCount++;
      UpdateScoreText();
    }

    public void Reset()
    {
      _hitCount = 1;
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
