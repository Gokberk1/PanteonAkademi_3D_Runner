using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddScore(); 
            Destroy(other.gameObject);
        }
    }

    public void AddScore()
    {
        score++;
        coinText.text = "Score" + score.ToString();
    }
}
