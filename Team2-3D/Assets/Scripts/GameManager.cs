using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] healthImages;
    private int currentHealth = 3;


    public AudioSource audioSource;
    public AudioClip pickupSFX;
    public AudioClip SnakeSFX;
    public AudioClip gotHurtSFX;


    public int pickups = 0;
    public TMP_Text pickupText;
    public GameObject enoughPickupsText;

    public GameObject mainMenuPanel;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHealth = healthImages.Length;
        mainMenuPanel.SetActive(false);
       // Win();

        
    }

    /*public void Win()
    {
        string currentScene;
        currentScene = SceneManager.GetActiveScene().name;

        if(//currentScene == "WIN")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    } */



    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            audioSource.clip = gotHurtSFX;
            audioSource.Play();// Decrease health

            UpdateData(); // Update UI to reflect new health

            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("Lose");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }



    public void UpdateData()
    {

        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].SetActive(true); // Show health image
            }
            else
            {
                healthImages[i].SetActive(false); // Hide health image
            }
        }


        pickupText.text = "Pickups: " + pickups;
    }




    // Update is called once per frame
    void Update()
    {
       




        if (Input.GetKeyUp(KeyCode.Q))
        {
            mainMenuPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
