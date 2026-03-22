using UnityEngine;
using Unity.Cinemachine;
using TMPro;

public class MentalStateSystem : MonoBehaviour
{
    public static MentalStateSystem Instance;

    [Range(0f, 100f)]
    public float MentalValue = 60f;

    [SerializeField] private float _maxValue = 100f;
    [SerializeField] private GameObject _potionPrefab;

    [Header("Stalker")]
    [SerializeField] private GameObject _stalkerEnemyPrefab;
    [SerializeField] private Transform _player;
    private GameObject _currentStalker;

    [Header("Screamer")]
    [SerializeField] private GameObject _screamerEnemyPrefab;
    [SerializeField] private float _screamerSpawnDistanceMin = 3f;
    [SerializeField] private float _screamerSpawnDistanceMax = 5f;

    [Header("Camera Effects")]
    [SerializeField] private CinemachineCamera _camera;
    [SerializeField] private float _maxShake = 2f;

    [Header("Mental Increase")]
    [SerializeField] private float _passiveIncreaseSpeed = 0.25f;
    [SerializeField] private float _stalkerBonusIncrease = 0.5f;

    [Header("UI")]
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoText;

    private bool _stalkerActive = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        HandleStalker();          // сначала обновляем состояние
        HandleMentalIncrease();   // потом считаем рост
        HandleEffects();
    }

    // ===================== MENTAL =====================

    public void AddMental(float amount)
    {
        if (MentalValue >= _maxValue) return;

        MentalValue += amount;
        MentalValue = Mathf.Clamp(MentalValue, 0f, _maxValue);
    }

    public void ReduceMental(float amount)
    {
        if (MentalValue <= 0f) return;

        MentalValue -= amount;
        MentalValue = Mathf.Clamp(MentalValue, 0f, _maxValue);
    }

    private void HandleMentalIncrease()
    {
        float speed = _passiveIncreaseSpeed;

        if (_stalkerActive)
        {
            speed += _stalkerBonusIncrease;
        }

        // (опционально) усиление от текущей менталки
        float stressMultiplier = 1f + (MentalValue / 200f);

        AddMental(speed * stressMultiplier * Time.deltaTime);
    }

    // ===================== STALKER =====================

    private void HandleStalker()
    {
        if (MentalValue >= 80f)
        {
            if (!_stalkerActive)
            {
                SpawnStalker();
                _stalkerActive = true;
            }
        }
        else
        {
            if (_stalkerActive)
            {
                DespawnStalker();
                _stalkerActive = false;
            }
        }
    }

    private void SpawnStalker()
    {
        if (_stalkerEnemyPrefab == null || _player == null) return;

        Vector3 spawnPos = _player.position + Random.insideUnitSphere * 3f;
        spawnPos.y = _player.position.y;

        _currentStalker = Instantiate(_stalkerEnemyPrefab, spawnPos, Quaternion.identity);

        var enemy = _currentStalker.GetComponent<IEnemy>();
        enemy?.Initialize(_player);
    }

    private void DespawnStalker()
    {
        if (_currentStalker != null)
            Destroy(_currentStalker);
    }

    // ===================== EFFECTS =====================

    private void HandleEffects()
    {
        if (_camera == null) return;

        float normalized = MentalValue / _maxValue;

        var noise = _camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        if (noise != null)
        {
            noise.AmplitudeGain = normalized * _maxShake;
        }

        if (MentalValue >= 100f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _infoPanel.SetActive(true);
        _infoText.text = "Your mind is broken... You lose!";
        Time.timeScale = 0f;
    }

    // ===================== SPAWN =====================

    public void SpawnScreamer()
    {
        Vector3 direction = Random.onUnitSphere;
        direction.z = 0f;
        direction.Normalize();

        float distance = Random.Range(_screamerSpawnDistanceMin, _screamerSpawnDistanceMax);

        Vector3 pos = _player.position + direction * distance;
        pos.z = _player.position.z;

        GameObject obj = Instantiate(_screamerEnemyPrefab, pos, Quaternion.identity);
        obj.transform.SetParent(transform);

        var enemy = obj.GetComponent<IEnemy>();
        enemy?.Initialize(_player);
    }

    public void SpawnPotion()
    {
        Vector3 direction = Random.onUnitSphere;
        direction.z = 0f;
        direction.Normalize();

        float distance = Random.Range(_screamerSpawnDistanceMin, _screamerSpawnDistanceMax);

        Vector3 pos = _player.position + direction * distance;
        pos.z = _player.position.z;

        GameObject obj = Instantiate(_potionPrefab, pos, Quaternion.identity);
        obj.transform.SetParent(transform);
    }
}