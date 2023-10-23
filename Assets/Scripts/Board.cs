using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Capsule;
    public GameObject Cylinder;
    public GameObject Sphere;
    //public GameObject Plane;

    public List<GameObject> shapes = new List<GameObject>(); // a list for storing the different shapes that can be shown in one grid block (row, column)

    //public int vertical;
    //public int horizontal; // will hold the verical and horizontal size of our screen based off orthographic camera;

    public GameObject backgroundTile; // this is the tile piece to set up the game board.
    public GameObject[,] Grid; //2D array that represent grid structure 
    
    public int rows;
    public int columns; // rows and columns of the grid

    // Start is called before the first frame update
    void Start()
    {
        shapes.Add(Cube);
        shapes.Add(Capsule);
        shapes.Add(Cylinder);
        shapes.Add(Sphere); // adding all the possible shapes to my list
        
        rows = 9;
        columns = 9;

        Grid = new GameObject[rows, columns];

        int shapeIdx; 

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                Vector2 pos = new Vector2(i, j);

                GameObject bgTile = Instantiate(backgroundTile, pos, Quaternion.identity); // creating a tile with the postion of the array and quaternion.idneitity means no rotation. 

                bgTile.transform.parent = transform;

                bgTile.name = "Tile - [" + i + ", " + j + "]";

                shapeIdx = Random.Range(0, 4); // random index for selecting shape from list

                SpawnShape(new Vector2Int(i, j), shapes.ElementAt(shapeIdx));
            } 
        }
       
    }

    void SpawnShape(Vector2Int spawnPos, GameObject shapeToSpawn)
    {
        GameObject shp = Instantiate(shapeToSpawn, new Vector3(spawnPos.x, spawnPos.y), Quaternion.identity);
        shp.transform.parent = this.transform;
        shp.name = "Shape -" + spawnPos.x + "," + spawnPos.y;
        Grid[spawnPos.x, spawnPos.y] = shp;

        //SetupShape(spawnPos, this);
    }

    public Vector2Int posIndex;
    public Board board; 

    public void SetupShape (Vector2Int pos, Board Board)
    {
        posIndex = pos;
        board = Board; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
