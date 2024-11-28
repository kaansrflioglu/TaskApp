import React, { useState, useEffect } from "react";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import TaskList from "./TaskList";
import TaskCreationForm from "./TaskCreationForm";
import TaskEditForm from "./TaskEditForm";

function TaskManager() {
  const [tasks, setTasks] = useState([]);
  const [editTask, setEditTask] = useState(null);

  useEffect(() => {
    fetchTasks();
  }, []);

  const fetchTasks = () => {
    axios
      .get("http://localhost:5000/api/Task")
      .then((response) => setTasks(response.data))
      .catch((error) => toast.error(`Failed to fetch tasks: ${error.message}`));
  };

  const handleCreateTask = (task) => {
    axios
      .post("http://localhost:5000/api/Task", task)
      .then(() => {
        toast.success("Task created successfully!");
        fetchTasks();
      })
      .catch((error) => toast.error(`Failed to create task: ${error.message}`));
  };

  const handleEditTask = (task) => {
    axios
      .put(`http://localhost:5000/api/Task/${task.id}`, task)
      .then(() => {
        toast.success("Task updated successfully!");
        fetchTasks();
        setEditTask(null);
      })
      .catch((error) => toast.error(`Failed to update task: ${error.message}`));
  };

  return (
    <div>
      <ToastContainer />
      <TaskCreationForm onCreate={handleCreateTask} />
      <TaskList tasks={tasks} onEdit={setEditTask} />
      {editTask && (
        <TaskEditForm task={editTask} onSave={handleEditTask} onCancel={() => setEditTask(null)} />
      )}
    </div>
  );
}

export default TaskManager;
