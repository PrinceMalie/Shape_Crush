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
    public GameObject Plane;

    public List<GameObject> shapes = new List<GameObject>(); // a list for storing the different shapes that can be shown in one grid block (row, column)

    public int vertical;
    public int horizontal; // will hold the verical and horizontal size of our screen based off orthographic camera;

    public int[,] Grid; //2D array that represent grid structure 
    
    public int rows;
    public int columns; // rows and columns of the grid

    // Start is called before the first frame update
    void Start()
    {
        shapes.Add(Cube);
        shapes.Add(Capsule);
        shapes.Add(Cylinder);
        shapes.Add(Sphere); // adding all the possible shapes to my list

        vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);

        GameObject board_background = Instantiate(Plane) as GameObject;
        board_background.transform.position = new Vector3(4, vertical, 250f);

        //rows = vertical * 2;
        //columns = horizontal * 2;

        
        rows = 9;
        columns = 9;

        Grid = new int[rows, columns];

        int shapeIdx; 

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                shapeIdx = Random.Range(0, 4); // random index for selecting shpae from list

                GameObject shape = Instantiate(shapes.ElementAt(shapeIdx)) as GameObject; // creates clone of shape selected

                shape.name = shape.name + " [" + i + ", " + j + "]";

                shape.transform.position = new Vector3(i, j, 5); //changes the position of the shape to the postion of the 2D array created
            } //- (vertical - 0.5f) & - (horizontal - 0.5f)
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
