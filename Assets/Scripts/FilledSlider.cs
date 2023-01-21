using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FilledSlider : MonoBehaviour
{
    private Image _image;

    public void Init(float minutes)
    {
        _image = GetComponent<Image>();

        _image.fillAmount = 0f;

        StartCoroutine(Sliding(minutes));
    }

    private IEnumerator Sliding(float minutes)
    {
        while (true)
        {
            _image.fillAmount += Time.deltaTime / (minutes * 60f);

            if (_image.fillAmount >= 1f)
                _image.fillAmount = 0f;

            yield return null;
        }
    }
}
