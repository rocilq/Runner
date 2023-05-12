using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score = score + 1;
            scoreText.text = "Score: " + score;
        }
    }
}
