using UI;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject _player;
    public Backpack _Backpack;
    private Storage _storage;
    private GameData _gameData;

    private void Start()
    {
        _storage = new Storage();
        LoadData();
    }

    public void SaveData()
    {
        _gameData.position = _player.transform.position;
        _storage.Save(_gameData);
    }

    public void LoadData()
    {
        _gameData = (GameData)_storage.Load(new GameData());
        _player.transform.position = _gameData.position;
    }
}
