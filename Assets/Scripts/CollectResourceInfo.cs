using UnityEngine;
using UnityEngine.UI;

public class CollectResourceInfo : MonoBehaviour
{
    private Image _image;
    private Animator _animator;

    public void Init(Building building)
    {
        _image = GetComponent<Image>();
        _animator = GetComponent<Animator>();

        _image.sprite = building.GeneratedMinerals[0].Mineral.Sprite;
    }

    public void ShowInfo()
    {
        _animator.SetTrigger("Collect");
    }
}
