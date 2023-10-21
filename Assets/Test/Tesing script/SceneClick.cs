using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneClick : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(gameObject);
        UIManager.Instance.LevelComplete();
    }
}