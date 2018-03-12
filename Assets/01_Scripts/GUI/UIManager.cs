using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject _hitEffectBackGround;
    private CanvasGroup _hitEffectBackGroundCanvasGroup;
    private Image _hitEffectBackGroundImg;

    [SerializeField]
    private Image _gauge;
    [SerializeField]
    private Text _gameOver;
    [SerializeField]
    private TextMesh _time;

    public int _leftTime = 100;

    public void Start()
    {
        _hitEffectBackGroundCanvasGroup = _hitEffectBackGround.GetComponent<CanvasGroup>();
        _hitEffectBackGroundImg = _hitEffectBackGround.GetComponent<Image>();
    }

    public void Update()
    {
        _time.text = _leftTime.ToString();
    }

    public void TimeTicker(System.Object source, System.Timers.ElapsedEventArgs e)
    {
        _leftTime--;
        if (_leftTime < 0)
            DataManager.Instance.GameOver();
    }
    
    public void ChangeBGColor(COLOR_TYPE type) {

        _hitEffectBackGroundCanvasGroup.alpha = 0.5f;

        switch (type) {
            case COLOR_TYPE.POSITIVE:
                _hitEffectBackGroundImg.color= Color.cyan;
                break;
            case COLOR_TYPE.NEGATIVE:
                _hitEffectBackGroundImg.color = Color.red;
                break;
            case COLOR_TYPE.SPECIAL:
                _hitEffectBackGroundImg.color = Color.white;
                break;
            default: break;    
        }

        
        StartCoroutine(ReduceAlpha(_hitEffectBackGroundCanvasGroup));
    }

    IEnumerator ReduceAlpha(CanvasGroup grp) {

        while (grp.alpha != 0) {
            grp.alpha -= 0.7f*Time.deltaTime;

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
        _hitEffectBackGroundImg.color = Color.black;
        
        _gameOver.text = "Game Over";
        _time.text = "";

        while (_hitEffectBackGroundCanvasGroup.alpha != 1)
        {
            _hitEffectBackGroundCanvasGroup.alpha += 0.1f*Time.deltaTime;
            
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine("GameOver");
    }


}
public enum COLOR_TYPE {
    POSITIVE,
    NEGATIVE,
    SPECIAL
}