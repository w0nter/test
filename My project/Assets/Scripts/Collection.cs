using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Collection : MonoBehaviour
{
    private int maxCount = 9;
    private int actualCount = 0;
    public TextMeshProUGUI progressText;
    public GameObject gameOverPanel;
    public GameObject joystickObject;
    public GameObject touchScreen;
    void Start()
    {
        UpdateCounter();
        gameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            Destroy(other.gameObject);

            if (actualCount < maxCount)
            {
                actualCount++;
                UpdateCounter();

                if (actualCount >= maxCount)
                {
                    GameOver();
                }
            }
        }
    }

    private void UpdateCounter()
    {
        progressText.text = actualCount + " / " + maxCount;
    }

    private void GameOver()
    {
        touchScreen.SetActive(false);
        joystickObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {

        SceneManager.LoadScene("SampleScene");
    }
}
