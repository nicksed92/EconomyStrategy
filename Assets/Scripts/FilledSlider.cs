using UnityEngine;
using UnityEngine.UI;

public class FilledSlider : MonoBehaviour
{
    private Image _image;

    public void Init(Color color)
    {
        _image = GetComponent<Image>();
        _image.color = color;
        _image.fillAmount = 0f;
    }

    public void SetImageFilling(float value)
    {
        _image.fillAmount = value;
    }
}
