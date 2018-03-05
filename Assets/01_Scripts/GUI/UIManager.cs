using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Image _hitEffectBackGround;
    [SerializeField]
    private Image _gauge;
    [SerializeField]
    private Text _gameOver;
    [SerializeField]
    private Text _time;

    public void Start()
    {
        Color clr = _hitEffectBackGround.color;
        clr.a = 0f;
        _hitEffectBackGround.color = clr;
    }

    private void Update()
    {
        _time.text = DataManager.Instance.score.ToString();
    }

    public void ChangeBGColor(COLOR_TYPE type) {

        Color color;
        color = _hitEffectBackGround.color;
        color.a = 1;
        _hitEffectBackGround.color = color;

        
        switch (type) {
            case COLOR_TYPE.POSITIVE:
                _hitEffectBackGround.color = Color.cyan;
                break;
            case COLOR_TYPE.NEGATIVE:
                _hitEffectBackGround.color = Color.red;
                break;
            case COLOR_TYPE.SPECIAL:
                _hitEffectBackGround.color = Color.white;
                break;
            default: break;    
        }

        color = _hitEffectBackGround.color;
        StartCoroutine(ReduceAlpha(color));
    }

    IEnumerator ReduceAlpha(Color clr) {

        while (clr.a != 0) {
            clr.a -= 0.2f*Time.deltaTime;
            _hitEffectBackGround.color = clr;

            yield return new WaitForSeconds(0.0001f);
        }
    }

    public void ChangeGaugeScore(int score,int originScore) {
        _gauge.fillAmount += score/originScore; 
    }

    public void ShowGameOver() {

        StartCoroutine("GameOver");
    }

    IEnumerator GameOver()
    {
        Color clr;

        _hitEffectBackGround.color = Color.black;
        clr = _hitEffectBackGround.color;

        while (clr.a != 0)
        {
            clr.a -= 0.1f*Time.deltaTime;
            _hitEffectBackGround.color = clr;
            yield return new WaitForSeconds(0.01f);
        }

        _gameOver.text = "Game Over";
    }


}
public enum COLOR_TYPE {
    POSITIVE,
    NEGATIVE,
    SPECIAL
}