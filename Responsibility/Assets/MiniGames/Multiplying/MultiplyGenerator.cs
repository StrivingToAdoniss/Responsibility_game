using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiplyGenerator : MonoBehaviour
{
    private int size;
    private List<NumberScript> numbersList;
    private NumberScript prefab;

    public void Initialize(int size, NumberScript prefab)
    {
        this.size = size;
        this.prefab = prefab;
    }

    public (List<NumberScript>, List<NumberScript>, int) CreateLevelData()
    {
        int estimatedSum = 0;

        numbersList = CreatePrefabsList();
        Utils.ShuffleList(numbersList);

        List<NumberScript> result = new List<NumberScript>();

        for (int i = 0; i < numbersList.Count; i++)
        {
            if (i < size)
            {
                result.Add(numbersList[i]);
                if (i % 2 == 1)
                {
                  estimatedSum += numbersList[i - 1].GetValue() * numbersList[i].GetValue();
                }
            }
            else
            {
                Destroy(numbersList[i].gameObject);
            }
        }

        numbersList.RemoveRange(size, numbersList.Count - size);
        Utils.ShuffleList(numbersList);

        result.Reverse();
        return (result, numbersList, estimatedSum);
    }

    private List<NumberScript> CreatePrefabsList()
    {
        numbersList = new List<NumberScript>();

        for (int i = 1; i < 10; i++)
        {
            NumberScript newNumber = Instantiate(prefab);
            newNumber.Init(i);

            numbersList.Add(newNumber);
        }

        return numbersList;
    }
}