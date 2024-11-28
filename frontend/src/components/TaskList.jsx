import React from "react";

function TaskList({ tasks, onEdit }) {
  return (
    <div className="task-list">
      <h2>Task List</h2>
      {tasks.length === 0 ? (
        <p>No tasks available.</p>
      ) : (
        <ul>
          {tasks.map((task) => (
            <li key={task.id}>
              <h3>{task.title}</h3>
              <p>{task.description || "No description provided."}</p>
              <small>Created At: {new Date(task.createdAt).toLocaleString()}</small>
              <br />
              <button onClick={() => onEdit(task)}>Edit</button>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default TaskList;
