using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conditions : MonoBehaviour
{
    public AudioClip WinAudio;
    public AudioClip LoseAudio;
    public AudioClip RestartAudio;

    public static bool Lose = false;
    public static bool Win = false;

    private int GameLength = 15;

    void Update()
    {
        int items = 0;

        for (int x = 0; x < GridConstructor.accessWidth; x++)
        {
            for (int y = 0; y < GridConstructor.accessHeight; y++)
            {
                if (GridConstructor.Matrix[x, y] == (int)GridConstructor.Cells.Item)
                {
                    items++;
                }
            }
        }

        if (items == 0)
        {
            Win = true;
        }

   

        if (Lose) 
        {
            SoundManager.PlaySingle(LoseAudio);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Lose = false;
        }

        if (Win)
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 < GameLength)
            {
                SoundManager.PlaySingle(WinAudio);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Win = false;
            }
            else 
            {
                //Credits
                Win = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SoundManager.PlaySingle(RestartAudio);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
