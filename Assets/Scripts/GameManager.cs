using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private PlayerController _playerController;
    private FishSpawner _fishSpawner;
    private DolphinSpawner _dolphinSpawner;
    
    [SerializeField] private float waterLevel;
    
    [SerializeField] private CountdownTimer countdownTimer;
    [SerializeField] private GameObject mainCamera;

    public PlayerController PlayerController => _playerController;
    public CountdownTimer CountdownTimer => countdownTimer;
    public FishSpawner FishSpawner => _fishSpawner;
    public DolphinSpawner DolphinSpawner => _dolphinSpawner;
    public float WaterLevel => waterLevel;
    
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                Debug.LogError("Game Manager Instance is Null!");
            }
            
            return _instance;
        }
    }
    

    private void Awake()
    {
        _instance = this;

        if (!GameObject.FindGameObjectWithTag("Player").TryGetComponent(out _playerController))
        {
            Debug.LogError("Player Controller Component not found!");
        }
        
        /*GameObject water = GameObject.FindGameObjectWithTag("Water");
        if (water)
        {
            waterLevel = water.transform.position.y;
        }
        else
        {
            Debug.LogError("Water not found.");
        }*/

        if (!GameObject.FindGameObjectWithTag("FishSpawner").TryGetComponent(out _fishSpawner))
        {
            Debug.LogError("Fish Manager is Missing.");
        }
        
        if (!GameObject.FindGameObjectWithTag("DolphinSpawner").TryGetComponent(out _dolphinSpawner))
        {
            Debug.LogError("Dolphin Spawner is Missing.");
        }
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        
        if (_playerController.IsInWater)
        {
            mainCamera.GetComponent<Volume>().enabled = true;
        }
        
        if(!_playerController.IsInWater || _playerController.IsAtSurface)
        {
            mainCamera.GetComponent<Volume>().enabled = false;
        }
    }
}
