using System;

public static class GameEvents
{
    public static event Action<int> OnPelletsChanged;
    public static event Action<int> OnLivesChanged;
    public static event Action OnGameOver;
    public static event Action OnLevelCompleted;
    public static event Action OnWaveCompleted;

    public static void PelletsChanged(int amount) => OnPelletsChanged?.Invoke(amount);
    public static void LivesChanged(int amount) => OnLivesChanged?.Invoke(amount);
    public static void GameOver() => OnGameOver?.Invoke();
    public static void LevelCompleted() => OnLevelCompleted?.Invoke();
    public static void WaveCompleted() => OnWaveCompleted?.Invoke();
}