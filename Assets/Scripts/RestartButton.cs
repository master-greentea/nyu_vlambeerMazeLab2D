using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            FloorMaker.globalTileCount = 0;
            FloorMaker.generatedTiles.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }
}
