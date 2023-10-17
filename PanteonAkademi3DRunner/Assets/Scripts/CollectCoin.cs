using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject player;
    Animator playerAnim;
    [SerializeField] GameObject endPanel;

    private void Start()
    {
        playerAnim = player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddScore(); 
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;
            endPanel.SetActive(true); 

            if(score >= 10)
            {
                playerAnim.SetBool("win",true);
            }
            else
            {
                playerAnim.SetBool("lose", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collision"))
        {
            Debug.Log("touched obstacle");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore()
    {
        score++;
        coinText.text = "Score" + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
