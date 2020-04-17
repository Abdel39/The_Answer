using System.IO;
using System.Net;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;


public class LevelGenerator : MonoBehaviour {

    public Texture2D map ;
        

    public ColorToPrefab[] colorMappings;

    
    void Start ()
    {
        FetchTheImage();
        GenerateLevel();
    }
    
    void FetchTheImage()
    {
        /*string path = "C:\\Users\\futil\\Desktop\\New_Piskel.png";
        // y faut juste que le path nous ramene a un dossier "lvlImage" que l on creera et qui contiendra l image du nouveau niveau
        byte[] photoInBytes = File.ReadAllBytes(path);
        bool mapAvaiable = this.map.LoadImage(photoInBytes);
        if (!mapAvaiable)
        {
            //afficher un message d erreur
        }*/
      
    }
    void GenerateLevel ()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile (int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0 || pixelColor.Equals(new Color(255,255,255)))
        {
            // le pixel est transparent ou blanc donc on fait rien
            return;
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