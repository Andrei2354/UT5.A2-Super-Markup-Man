using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int currentLevel = 1;
    public int totalBoxes;
    private static int boxesDestroyed = 0;
    private HtmlBoxSpawner spawner;
    
    public TextMeshProUGUI levelText; 
    private string[] levelMessages = { "¡Nivel 1: Básico!", "¡Nivel 2: Básico!", "¡Nivel 3: Básico!", "¡Nivel 4: Intermedio!", "¡Nivel 5: Avanzado!", "¡Ganaste el juego!" };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        spawner = FindObjectOfType<HtmlBoxSpawner>();
        StartLevel();
    }

    void Update()
    {
        if (boxesDestroyed == totalBoxes)
        {
            Debug.Log("¡Nivel completado!");
            NextLevel();
        }
    }

    public static void IncrementDestroyedBoxes()
    {
        boxesDestroyed++;
    }

    void StartLevel()
    {
        boxesDestroyed = 0;
        HtmlBox.currentBoxIndex = 0;

        Interface.instance.ReiniciarTexto();

        if (currentLevel <= levelMessages.Length - 1)
        {
            levelText.text = levelMessages[currentLevel - 1]; 
            spawner.SpawnBoxes(currentLevel);
        }
    }

    void NextLevel()
    {
        if (currentLevel < levelMessages.Length - 1) 
        {
            currentLevel++;
            StartLevel();
        }
        else
        {
            levelText.text = levelMessages[levelMessages.Length - 1];
            Debug.Log("¡Ganaste el juego!");
        }
    }

    public void RestartGame()
    {
        currentLevel = 1;  
        boxesDestroyed = 0; 
        HtmlBox.currentBoxIndex = 0;
        instance = null;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
