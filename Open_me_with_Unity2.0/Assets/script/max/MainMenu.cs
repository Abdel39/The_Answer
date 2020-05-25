using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Hub");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LauchLevelEditor()
    {
        string my_path = Application.dataPath + @"/lvlEditor/" + "editeur_de_niveau.exe";

        System.Diagnostics.Process.Start(my_path);

      
    }
}
