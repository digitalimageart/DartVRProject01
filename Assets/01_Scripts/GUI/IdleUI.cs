using UnityEngine;
using UnityEngine.UI;

public class IdleUI : MonoBehaviour {

    public Image bgImage;
    private Color _bgColor;

    private void Start()
    {
        _bgColor = bgImage.color;
        _bgColor.a = 0.5f;
        bgImage.color = _bgColor;
    }
}
