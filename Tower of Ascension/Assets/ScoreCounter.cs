using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeReference] private TextMeshProUGUI scoreCounterText;
    int CoinsCollected = 0;

    public static ScoreCounter singleton;

    void Awake()
    {
        if (singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void RegisterCoin()
    {
        CoinsCollected += 1;
        scoreCounterText.text = CoinsCollected.ToString();
    }
}
