using UnityEngine;

[CreateAssetMenu(fileName = "Mineral", menuName = "ScriptableObjects/Mineral", order = 1)]
public class Mineral : ScriptableObject
{
    [SerializeField] private Minerals _entity;
    [SerializeField] private Sprite _sprite;

    public string Name => _entity.ToString();
    public Minerals Entity => _entity;
    public Sprite Sprite => _sprite;
}