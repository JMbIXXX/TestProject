using UnityEngine;

public class Load : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    
    [SerializeField] private Save _save;
    private Storage _storage;
    private GameData _gameData;
    private void Start()
    {
        _storage = new Storage();
    }

    public void LoadData()
    {
        _gameData = (GameData)_storage.Load(new GameData());
        _player.transform.position = _gameData.position;
    }
}
