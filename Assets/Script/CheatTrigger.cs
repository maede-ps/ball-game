using UnityEngine;

public class CheatTrigger : MonoBehaviour
{
    public int cheatClickCount = 5;
    public int coinsToAdd = 50;

    private int currentClicks = 0;
    private float resetTimer = 0f;
    public float resetTimeLimit = 2f; // چند ثانیه وقت داره بزنه همه رو

    private void Update()
    {
        if (resetTimer > 0f)
        {
            resetTimer -= Time.deltaTime;
        }
        else
        {
            currentClicks = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            // بررسی گوشه بالا چپ صفحه
            if (clickPos.x < 0.2f && clickPos.y > 0.8f)
            {
                currentClicks++;
                resetTimer = resetTimeLimit;

                if (currentClicks >= cheatClickCount)
                {
                    ActivateCheat();
                    currentClicks = 0;
                }
            }
        }
    }

    void ActivateCheat()
    {
        game_maneger.Instance.AddScore(coinsToAdd);
        Debug.Log("Cheat Activated! +" + coinsToAdd + " سکه 😈");
    }
}
