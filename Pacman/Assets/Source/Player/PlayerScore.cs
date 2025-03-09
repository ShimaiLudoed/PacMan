using TMPro;
using UnityEngine;

namespace Player
{
  public class PlayerScore : MonoBehaviour
  {
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
    }
    
    private void UpdateScoreText()
    {
      scoreText.text = "Очки: " + _score.ToString(); // Обновляем текст
    }

  }
}
