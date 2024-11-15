using System;

public static class GameEvent {

    public static event Action onPause;
    public static event Action onResume;
    public static event Action onGameOver;
    public static event Action onVictory;

    //Metodo con una sola linea usa =>.
    public static void TriggerPause() => onPause?.Invoke();
    public static void TriggerResume() => onResume?.Invoke();
    public static void TriggerGameOver() => onGameOver?.Invoke();
    public static void TriggerVictory() => onVictory?.Invoke();
}
