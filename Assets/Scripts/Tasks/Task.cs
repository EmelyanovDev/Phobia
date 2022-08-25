using UnityEngine;

namespace Tasks
{
    
    
    public abstract class Task : ScriptableObject
    {
        [SerializeField] private string taskDescription;

        public string TaskDescription => taskDescription;

        public abstract void CheckExecution();
    }
}
/*
Услышать голос призрака из рации
Получить 5-й уровень активности на анемометре
Спугнуть призрака при помощи креста
*/