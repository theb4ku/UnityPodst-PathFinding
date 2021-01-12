using System;
using UnityEngine;

public class MyGrid<TGridObject>
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;
    public MyGrid(int width, int height, float cellSize, Vector3 originPosition, Func<MyGrid<TGridObject>,int,int,TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];
        
        bool showDebug = true;
        if (showDebug)
        {
            debugTextArray = new TextMesh[width, height];
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                    gridArray[x, z] = createGridObject(this,x,z);
                debugTextArray[x, z] = Utility.CreateWorldText(gridArray[x, z]?.ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);

            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f); //horizontal line
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f); //vertical line
        }



    }
    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }
    public void GetXZ(Vector3 worldPosistion, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosistion - originPosition).x / cellSize);
        z = Mathf.FloorToInt((worldPosistion - originPosition).z / cellSize);
    }
    public void SetGridObject(int x, int z, TGridObject value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height) //if input values are invalid - ignore it!
        {
            gridArray[x, z] = value;
            debugTextArray[x, z].text = gridArray[x, z].ToString();
        }
    }
    public void SetGridObject(Vector3 worldPosistion, TGridObject value)
    {
        int x, z;
        GetXZ(worldPosistion, out x, out z);
        SetGridObject(x, z, value);
    }
    public TGridObject GetGridObject(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            return gridArray[x, z];
        }
        else
        {
            return default(TGridObject);
        }
    }
    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetGridObject(x, z);
    }
    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }
}
