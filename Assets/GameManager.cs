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

    // Update is called once per frame
    void Update()
    {
        
    }
}
