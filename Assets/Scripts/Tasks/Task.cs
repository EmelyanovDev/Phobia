using UnityEngine;

namespace Tasks
{
    [CreateAssetMenu(fileName = "Task", menuName = "New Task")]
    
    public abstract class Task : ScriptableObject
    {
        [SerializeField] private string taskDescription;

        public abstract void CheckExecution();
    }
}