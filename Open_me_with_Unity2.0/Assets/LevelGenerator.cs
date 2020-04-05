using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    // Use this for initialization
    void Start () {
        GenerateLevel();
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

        if (pixelColor.a == 0)
        {
            // le pixel est transparent donc on fait rien
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