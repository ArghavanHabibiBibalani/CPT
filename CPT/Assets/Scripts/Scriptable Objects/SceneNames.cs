
using UnityEngine;

[CreateAssetMenu(fileName = "Scene Names")]
public class SceneNames : ScriptableObject
{
    [SerializeField] private string _main;
    [SerializeField] private string _test;

    public string Main { get => _main; }
    public string Test { get => _test; }
}
