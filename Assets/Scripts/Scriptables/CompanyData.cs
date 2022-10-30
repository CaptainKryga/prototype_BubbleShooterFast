using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "CompanyData", menuName = "ScriptableObjects/CompanyData", order = 1)]
    public class CompanyData : ScriptableObject
    {
        public string[] Levels;
    }
}