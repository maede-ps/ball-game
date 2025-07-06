using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    private void Update()
    {
        if (game_maneger.Instance != null)
        {
            scoreText.text =  game_maneger.Instance.score.ToString();
            lifeText.text =  game_maneger.Instance.life.ToString();
        }
    }
}
