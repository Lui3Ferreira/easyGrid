using System.Collections.Generic;
using UnityEngine;

interface IGenerator
{
    void AddItemsToGrid(List<GameObject> gOs);
    void SetUpJsonGrid(int gridJsonIndex);
}
