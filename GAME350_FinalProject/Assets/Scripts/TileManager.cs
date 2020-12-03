using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        //LayTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Instantiate the tiles at the start
    void LayTiles()
    {   
        // the x length of each tile
        float tileSize = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        // the origin 
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                GameObject newTile = Instantiate(tile);
                newTile.transform.position = new Vector3(worldStart.x + (tileSize * x), worldStart.y - (tileSize * y), 0);
            }
        }
    }
}
