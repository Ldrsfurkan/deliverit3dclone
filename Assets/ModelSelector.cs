using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelector : MonoBehaviour
{
    public List<GameObject> packages;

    public void SetModel(int modelID)
    {
        packages[modelID].SetActive(true);
    }

}
