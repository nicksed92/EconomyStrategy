using UnityEngine;

[CreateAssetMenu(fileName = "Mineral", menuName = "ScriptableObjects/Mineral", order = 1)]
public class Mineral : ScriptableObject
{
    [SerializeField] private Minerals _entity;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;

    public string Name => _entity.ToString();
    public Minerals Entity => _entity;
    public Sprite Sprite => _sprite;
    public Color Color => _color;
}