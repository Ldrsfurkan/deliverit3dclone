using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelID = 0;
    public int step = 1;
    public float gap = 0.05f; // Path üzerindeki nesne aralığı
    public GameObject packagePrefab;
    public GameObject enemyPrefab;
    public GameObject finishPrefab;
    public List<List<int>> levels;
    public static LevelManager instance;

    private Vector3[][] paths; // Path noktalarının dizisi
    private int currentPathId = 0; // Kullanılacak path'in ID'si

    private void Awake()
    {
        CreateInstance();
    }

    void CreateInstance()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        // 0-bosluk, 1-package, 2-enemy, 3-finish
        levels = new List<List<int>>()
        {
            new List<int>() {1,0,1,0,1,0,1,0,2,0,1,0,1,0,1,0,1,0,0,3},
            new List<int>() {1,0,1,1,0,2,1,0,2,1,0,1,1,0,1,0,1,0,1,3},
            new List<int>() {1,0,1,1,2,1,0,0,1,0,2,1,0,0,1,1,2,0,0,3},
            new List<int>() {1,1,2,0,1,0,1,0,1,2,1,1,0,1,2,1,0,0,0,3},
            new List<int>() {1,2,1,0,1,2,1,0,0,1,2,1,1,1,1,1,0,2,0,3},
            new List<int>() {1,2,1,0,1,1,1,2,1,1,0,1,1,1,1,1,2,1,0,3}
        };
        levelID = PlayerPrefs.GetInt("levelID", levelID);
        //CreateLevel(levelID);
    }

    void Update()
    {
        RestartLevelID();
    }

    public void SetPaths(Vector3[][] newPaths, int pathId)
    {
        paths = newPaths;
       currentPathId = pathId;
       Debug.Log(pathId);
        CreateLevel(levelID);
    }

    public void CreateLevel(int levelID)
{
    if (paths == null || paths.Length == 0 || currentPathId < 0 || currentPathId >= paths.Length)
    {
        Debug.LogError("Invalid path configuration");
        return;
    }

    step = 1; // Her çağrıda step sıfırlanır
    Vector3[] currentPath = paths[currentPathId];

    float currentLength = 0f;
    bool finishPlaced = false; // Finish'in yerleştirilip yerleştirilmediğini kontrol etmek için

    for (int i = 0; i < currentPath.Length - 1; i++)
    {
        Vector3 start = currentPath[i];
        Vector3 end = currentPath[i + 1];
        float segmentLength = Vector3.Distance(start, end);

        while (currentLength <= segmentLength)
        {
            Vector3 position = Vector3.Lerp(start, end, currentLength / segmentLength);

            // Pozisyonun geçerli olup olmadığını kontrol et
            if (float.IsNaN(position.x) || float.IsNaN(position.y) || float.IsNaN(position.z) ||
                float.IsInfinity(position.x) || float.IsInfinity(position.y) || float.IsInfinity(position.z))
            {
                continue;
            }

            int objectType = levels[levelID][Mathf.Min(step - 1, levels[levelID].Count - 1)];

            if (objectType == 0)
            {
                // Boşluk, bir şey yapma
            }
            else if (objectType == 1)
            {
                var r = Random.Range(0, 3);
                Instantiate(packagePrefab, position, Quaternion.identity).GetComponent<ModelSelector>().SetModel(r);
            }
            else if (objectType == 2)
            {
                Instantiate(enemyPrefab, position, Quaternion.identity);
            }
            else if (objectType == 3 && !finishPlaced)
            {
                // Finish prefab'ı yolun sonunda yerleştirin
                Vector3 finishPosition = end; // Son noktada yerleştir
                Instantiate(finishPrefab, finishPosition, Quaternion.identity);
                finishPlaced = true; // Finish yerleştirildi olarak işaretle
            }

            currentLength += gap;
            step++;
        }

        // Segment uzunluğunu bir sonraki segmentin başlangıç noktasına kaydet
        currentLength -= segmentLength;
    }

    // Eğer finishPrefab hala yerleştirilmemişse, yolun sonunda yerleştir
    if (!finishPlaced && currentPath.Length > 0)
    {
        Vector3 finishPosition = currentPath[currentPath.Length - 1];
        Instantiate(finishPrefab, finishPosition, Quaternion.identity);
    }
}

    public void NewLevel()
    {
        step = 1; // step her yeni seviyede sıfırlanır
        levelID++;
        PlayerPrefs.SetInt("levelID", levelID);
        SceneManager.LoadScene("asd");
    }

    public void RestartLevelID()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("levelID", 0);
        }
    }
}

