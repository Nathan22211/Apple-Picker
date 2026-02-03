using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;
    private Text txtCom;

    void Awake() {
        _UI_TEXT = this.GetComponent<Text>();

        if (PlayerPrefs.HasKey("HighScore")) {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE {
        get {
            return _SCORE;
        }
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", _SCORE);
            if (_UI_TEXT != null) {
                _UI_TEXT.text = "High Score: " + _SCORE.ToString( "#,0" );
            }
        }
    }
    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the high score.")]
    public bool resetOnAwake = false;

    void OnDrawGizmos() {
        if (resetOnAwake) {
            resetOnAwake = false;
            PlayerPrefs.SetInt("HighScore", 0);
            Debug.LogWarning("High score reset to 0");
        }
    }
}
