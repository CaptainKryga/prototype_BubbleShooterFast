using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "CompanyData", menuName = "ScriptableObjects/CompanyData", order = 1)]
    public class DataCompany : ScriptableObject
    {
        public MapLevel[] Levels;
    }

    [Serializable]
    public class MapLevel
    {
        public string Level;
        public int[] Queue;
    }
}