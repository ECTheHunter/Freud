using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static PlayerController Player
    {
        get
        {
            if (_player == null)
                _player = (PlayerController)FindFirstObjectByType(typeof(PlayerController));
            return _player;
        }
    }
    private void Start()
    {
        SoundManager.Instance.StopMainTheme();
        SoundManager.Instance.PlayLevelSound = true;
        TransitionManager.Instance.CloseWhiteTransition(null);
    }
    private static PlayerController _player;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(Instance);
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void OnDisable()
    {
        SoundManager.Instance.PlayLevelSound = false;
    }
}
