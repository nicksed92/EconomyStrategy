using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FilledSlider : MonoBehaviour
{
    private Image _image;

    public void Init(Building building, CollectResourceInfo collectResourceInfo)
    {
        _image = GetComponent<Image>();
        _image.color = building.Color;
        _image.fillAmount = 0f;

        StartCoroutine(Sliding(building.GeneratedMinerals[0].Minutes, building.GeneratedMinerals[0].Mineral, collectResourceInfo));
    }

    private IEnumerator Sliding(float minutes, Mineral mineral, CollectResourceInfo collectResourceInfo)
    {
        while (true)
        {
            _image.fillAmount += Time.deltaTime / (minutes * 60f);

            if (_image.fillAmount >= 1f)
            {
                _image.fillAmount = 0f;
                collectResourceInfo.ShowInfo();
                GlobalEvents.OnMineralExtracted.Invoke(mineral);
            }

            yield return null;
        }
    }
}
