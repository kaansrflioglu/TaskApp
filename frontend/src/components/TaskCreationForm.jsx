import React, { useState } from "react";

function TaskCreationForm({ onCreate }) {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    const newTask = {
      title,
      description,
      createdAt: new Date().toISOString(), 
    };
    onCreate(newTask);
    setTitle("");
    setDescription("");
  };
  

  return (
    <form onSubmit={handleSubmit} className="task-creation-form">
      <h2>Create a Task</h2>
      <div>
        <label>Title:</label>
        <input
          type="text"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          required
        />
      </div>
      <div>
        <label>Description:</label>
        <textarea
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />
      </div>
      <button type="submit">Create Task</button>
    </form>
  );
}

export default TaskCreationForm;
