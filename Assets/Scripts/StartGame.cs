using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool gameIsStarted = false;

    public GameObject tutorialMenu;
    public GameObject healthUI;
    public GameObject scoreUI;

    public static StartGame instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de StartGame dans la scène");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameIsStarted = true;
        }

        if(gameIsStarted)
        {
            tutorialMenu.SetActive(false);
            healthUI.SetActive(true);
            scoreUI.SetActive(true);
        }
    }
}
