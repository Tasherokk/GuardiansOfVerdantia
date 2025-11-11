using UnityEngine;
using TMPro; // Assuming TextMeshPro is used for UI text
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private TextMeshProUGUI coreHealthText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private GameObject gameOverPanel; // Assuming a panel for game over
    [SerializeField] private TextMeshProUGUI gameOverText; // Text to display Win/Lose message
    [SerializeField] private GameObject gameWinPanel; // Assuming a panel for game win

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnManaChanged += UpdateManaDisplay;
            GameManager.Instance.OnCoreHealthChanged += UpdateCoreHealthDisplay;
            GameManager.Instance.OnWaveChanged += UpdateWaveDisplay;
            GameManager.Instance.OnGameWin += DisplayGameWin; // Subscribe to win event
            GameManager.Instance.OnGameLose += DisplayGameLose; // Subscribe to lose event
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnManaChanged -= UpdateManaDisplay;
            GameManager.Instance.OnCoreHealthChanged -= UpdateCoreHealthDisplay;
            GameManager.Instance.OnWaveChanged -= UpdateWaveDisplay;
            GameManager.Instance.OnGameWin -= DisplayGameWin; // Unsubscribe from win event
            GameManager.Instance.OnGameLose -= DisplayGameLose; // Unsubscribe from lose event
        }
    }

    private void Start()
    {
        // Initial display update
        if (GameManager.Instance != null)
        {
            UpdateManaDisplay(GameManager.Instance.PlayerMana);
            UpdateCoreHealthDisplay(GameManager.Instance.CoreHealth);
            UpdateWaveDisplay(GameManager.Instance.CurrentWave);
        }
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Ensure game over panel is hidden initially
        }
        if (gameWinPanel != null)
        {
            gameWinPanel.SetActive(false); // Ensure game win panel is hidden initially
        }
    }

    private void UpdateManaDisplay(int mana)
    {
        if (manaText != null)
        {
            manaText.text = $"Mana: {mana}";
        }
    }

    private void UpdateCoreHealthDisplay(int health)
    {
        if (coreHealthText != null)
        {
            coreHealthText.text = $"Core Health: {health}";
        }
    }

    private void UpdateWaveDisplay(int wave)
    {
        if (waveText != null)
        {
            waveText.text = $"Wave: {wave}/{GameManager.Instance.TotalWaves}"; // Display current/total waves
        }
    }

    private void DisplayGameWin()
    {
        if (gameWinPanel != null)
        {
            gameWinPanel.SetActive(true);
            if (gameOverText != null) gameOverText.text = "VICTORY!";
        }
        // Optionally pause game, disable input, etc.
    }

    private void DisplayGameLose()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (gameOverText != null) gameOverText.text = "DEFEAT!";
        }
        // Optionally pause game, disable input, etc.
    }
}