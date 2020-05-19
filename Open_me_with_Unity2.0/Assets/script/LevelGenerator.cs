using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class LevelGenerator : MonoBehaviour
{

    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public Transform player;



    public Dropdown dropdown;
    private static string my_path;
    private List<string> listLvl = new List<string>();

    public bool fromEditedScene;

    // Start is called before the first frame update
    void Start()
    {
        if (fromEditedScene && my_path!= null && my_path!="")
        {
            Debug.Log("depuis editScene");
            FetchTheImage();
            GenerateLevel();

        }
        else
        {
            InitDropDown();
            Debug.Log("pas depuis editScene");
        }

    }

    private void InitDropDown()
    {
        if (dropdown != null)
        {
            Debug.Log("j init ma dropdown");

            string path = Application.dataPath + @"/lvlEditor/";

            string[] my_list = Directory.GetFiles(path);

            foreach (string item in my_list)
            {
                FileInfo fileInfo = new FileInfo(item);


                int longueur = fileInfo.Name.Length;
                if (fileInfo.Extension == ".png")
                {
                    Debug.Log("j ai : " + fileInfo.Name.Substring(0, longueur - 4));


                    listLvl.Add(fileInfo.Name.Substring(0, longueur - 4));
                }
              
            }


            dropdown.AddOptions(listLvl);

            Debug.Log("je les ai ajouté a ma liste et a ma drop box");

            if (listLvl.Count > 0)
            {
                my_path = Application.dataPath + @"/lvlEditor/" + listLvl[0] + ".png";
            }
        }
       


    }

    public void onDropDownClick(int index)
    {


        my_path = Application.dataPath + @"/lvlEditor/" + listLvl[index] + ".png";

        Debug.Log("on vient de clické sur drop down, index : " + index + " ce qui est : " + my_path);


    }

    public void onLaunchEditSceneClicked()
    {
        SceneManager.LoadScene("EditedLvl");
    }


    private void FetchTheImage()
    {
        Debug.Log("fetch the image");

        if (my_path != null && my_path != "")
        {
            Debug.Log("je fetch l image");
            Debug.Log("son path : " + my_path);
            byte[] photoInBytes = File.ReadAllBytes(my_path);
            bool mapAvaiable = map.LoadImage(photoInBytes);
            Debug.Log("j ai une erreur : " + mapAvaiable);
        }
        else
        {
            Debug.Log("oupsi le path est vide ");
        }


    }

    private void GenerateLevel()
    {
        Debug.Log("generate level");



        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0 || pixelColor.Equals(new Color(255, 255, 255)))
        {
            // le pixel est transparent ou blanc donc on fait rien
            return;
        }
        if (pixelColor.r == 255 && pixelColor.b == 0 && pixelColor.g == 0 && player !=null)
        {
            player.position = new Vector2(x, y);
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                // le pixel a une couleur egale a celle d un de nos couleur predefini dans colorMappings,
                // donc on creer l element associé
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }

}