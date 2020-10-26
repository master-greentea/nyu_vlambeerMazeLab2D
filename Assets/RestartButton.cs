﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) {
			SceneManager.LoadScene("InterestingMinecraftRipoff");
		}
    }
}
