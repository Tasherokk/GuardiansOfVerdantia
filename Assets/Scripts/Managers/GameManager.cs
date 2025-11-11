using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int _playerMana = 100;
    [SerializeField] private int _coreHealth = 10;
    [SerializeField] private int _currentWave = 0;
    [SerializeField] private int _totalWaves = 5; // Added total waves

    public event Action<int> OnManaChanged;
    public event Action<int> OnCoreHealthChanged;
    public event Action<int> OnWaveChanged;
    public event Action OnGameWin; // New event for game win
    public event Action OnGameLose; // New event for game lose

    public int PlayerMana
    {
        get => _playerMana;
        set
        {
            if (_playerMana != value)
            {
                _playerMana = value;
                OnManaChanged?.Invoke(_playerMana);
            }
        }
    }

    public int CoreHealth
    {
        get => _coreHealth;
        set
        {
            if (_coreHealth != value)
            {
                _coreHealth = value;
                OnCoreHealthChanged?.Invoke(_coreHealth);
                if (_coreHealth <= 0)
                {
                    HandleGameLose();
                }
            }
        }
    }

    public int CurrentWave
    {
        get => _currentWave;
        set
        {
            if (_currentWave != value)
            {
                _currentWave = value;
                OnWaveChanged?.Invoke(_currentWave);
            }
        }
    }

    public int TotalWaves => _totalWaves; // Public getter for total waves

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: if GameManager should persist across scenes
        }
    }

    // Example methods for mana management
    public void AddMana(int amount)
    {
        PlayerMana += amount;
    }

    public bool TrySpendMana(int amount)
    {
        if (PlayerMana >= amount)
        {
            PlayerMana -= amount;
            return true;
        }
        return false;
    }

    // Example method for taking core damage
    public void TakeCoreDamage(int amount)
    {
        CoreHealth -= amount;
    }

    // Example method for advancing wave
    public void AdvanceWave()
    {
        CurrentWave++;
        // Logic for starting next wave
    }

    public void HandleGameWin()
    {
        Debug.Log("Game Won!");
        OnGameWin?.Invoke();
        // Pause game, show win screen, etc.
    }

    public void HandleGameLose()
    {
        Debug.Log("Game Lost!");
        OnGameLose?.Invoke();
        // Pause game, show lose screen, etc.
    }
}