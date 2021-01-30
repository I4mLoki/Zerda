using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] heartList;

    [SerializeField]
    private Sprite[] heartSpritesByAscendant;
    
    [SerializeField]
    private int heartParts = 4;

    private int _hearts;
    private int _remainingParts;

    private int _currentHeartIndex;

    private void Awake()
    {
        DeactivateHearts();
    }

    public void SetHealth(int health)
    {
        _hearts = health;
        _remainingParts = heartParts;
        _currentHeartIndex = _hearts - 1;
        ActivateHearts();
    }

    private void ActivateHearts()
    {
        for (var i = 0; i < _hearts; i++)
        {
            var heart = heartList[i];
            heart.SetActive(true);
        }
    }

    private void DeactivateHearts()
    {
        foreach (var heart in heartList)
            heart.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        for (var i = 0; i < damage; i++)
        {
            RenderHearts();
        }
    }

    private void RenderHearts()
    {
        _remainingParts--;

        var currentHeart = heartList[_currentHeartIndex];
        var currentImage = currentHeart.GetComponent<Image>();

        if (_remainingParts < 0)
            return;

        if (_remainingParts == 0 && _currentHeartIndex > 0)
        {
            _currentHeartIndex--;
            currentImage.sprite = heartSpritesByAscendant[_remainingParts];
            _remainingParts = heartParts;
        }
        else
            currentImage.sprite = heartSpritesByAscendant[_remainingParts];
    }
}