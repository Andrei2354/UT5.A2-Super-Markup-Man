using UnityEngine;

public class HtmlBoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    private Vector3 villageCenter = new Vector3(81, 22, 64);
    private float spawnRadius = 30f;

    private string[][] htmlTags = new string[][]{
        new string[] { "<div>", "text", "</div>" },
        new string[] { "<div>", "text", "</div>" },
        new string[] { "<div>", "text", "</div>" },
        new string[] { "<html>", "<head>", "<title>", "</title>", "</head>"},
        new string[] { "<html>", "<head>", "<title>", "</title>", "</head>", "<body>", "<header>", "</header>", "</body>", "</html>" }
    };

    private int[] numberOfBoxes = { 3, 3, 3, 5, 10 };

public void SpawnBoxes(int level)
{
    if (level - 1 >= htmlTags.Length) return;

    GameManager.instance.totalBoxes = 0; 
    GameManager.instance.totalBoxes = numberOfBoxes[level - 1]; 

    for (int i = 0; i < numberOfBoxes[level - 1]; i++)
    {
        Vector3 randomPosition = villageCenter + new Vector3(
            Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius)
        );

        GameObject newBox = Instantiate(boxPrefab, randomPosition, Quaternion.identity);
        HtmlBox boxScript = newBox.GetComponent<HtmlBox>();

        if (boxScript != null)
        {
            boxScript.htmlTag = htmlTags[level - 1][i % htmlTags[level - 1].Length];
            boxScript.myIndex = i;
        }
    }
}

}
