using UnityEngine;

namespace Tasks
{
    [CreateAssetMenu(fileName = "Task", menuName = "New Task")]
    
    public class Task : ScriptableObject
    {
        [SerializeField] private string taskDescription;

        public string TaskDescription => taskDescription;
        

    }
}
/*
Услышать голос призрака из рации
Получить 5-й уровень активности на анемометре
Спугнуть призрака при помощи креста
*/