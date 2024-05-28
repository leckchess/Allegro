using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class EndingSequence : MonoBehaviour
{
    [SerializeField] private Vector3 _targetLocalCameraPosition;
    [SerializeField] private Vector3 _targetLocalCameraRotation;

    [SerializeField] private Puzzle _puzzle;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _puzzleSphere;
    [SerializeField] private GameObject _monster;
    [SerializeField] private GameObject _butterflies;
    [SerializeField] private Volume _goodVolume;
    [SerializeField] private Volume _badVolume;
    [SerializeField] private float _endingSceneTime;


    private void Start()
    {
        _puzzle.OnPuzzleSolved += OnPuzzleSolved;
    }

    private async void OnPuzzleSolved()
    {
        Transform camera = Camera.main.transform;
        var cameraPosition = camera.localPosition;
        var cameraRotation = camera.localRotation;
        float alpha = 0;
        _monster.SetActive(false);
        _puzzleSphere.SetActive(false);
        _player.SetActive(true);
        Instantiate(_butterflies, _player.transform);
        for (int i = 0; i < 100; i++)
        {
            await Task.Delay(20);
            alpha = (i + 1) / 100f;
            camera.localPosition = Vector3.Lerp(cameraPosition, _targetLocalCameraPosition, alpha);
            camera.LookAt(_player.transform);
            //camera.localRotation = Quaternion.Lerp(cameraRotation, Quaternion.Euler(_targetLocalCameraRotation), alpha);
            _goodVolume.weight = alpha;
            _badVolume.weight = 1 - alpha;
        }

        Invoke("EndLevel", _endingSceneTime);
    }

    private void EndLevel()
    {
        SceneManager.LoadScene(0);
    }
}