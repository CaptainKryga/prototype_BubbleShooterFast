using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "CompanyData", menuName = "ScriptableObjects/CompanyData", order = 1)]
    public class DataCompany : ScriptableObject
    {
        public string[] Levels;
    }
}