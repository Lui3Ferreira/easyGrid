using System.Collections.Generic;
using UnityEngine;

namespace GeneratorInterface
{
    interface IGenerator
    {
        void AddItemsToGrid(List<GameObject> gOs);
        void SetUpJsonGrid(int gridJsonIndex);
    }
}


