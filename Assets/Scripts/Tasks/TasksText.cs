using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Tasks
{
    [RequireComponent(typeof(TMP_Text))]
    
    public class TasksText : MonoBehaviour
    {
        [SerializeField] private int tasksCount;
        
        [SerializeField] private List<Task> _tasks;
        private TMP_Text _text;
        private const string TasksPath = "Tasks";

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _tasks = Resources.LoadAll<Task>(TasksPath).ToList();
            LoadText();
        }

        private void LoadText()
        {
            for (int i = 0; i < tasksCount; i++)
            {
                var randomTask = TakeRandomTask();
                _text.text += randomTask.TaskDescription;
                _text.text += "\n";
            }
        }

        private Task TakeRandomTask()
        {
            int taskIndex = Random.Range(0, _tasks.Count);
            var task = _tasks[taskIndex];
            _tasks.Remove(task);
            return task;
        }
    }
}