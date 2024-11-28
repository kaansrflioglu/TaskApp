import React, { useState } from "react";
import { Form, Button } from "react-bootstrap";

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
    <Form onSubmit={handleSubmit} className="mb-4">
      <h3>Create a Task</h3>
      <Form.Group className="mb-3">
        <Form.Label>Title</Form.Label>
        <Form.Control
          type="text"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          required
          placeholder="Enter task title"
        />
      </Form.Group>
      <Form.Group className="mb-3">
        <Form.Label>Description</Form.Label>
        <Form.Control
          as="textarea"
          rows={3}
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          placeholder="Enter task description"
        />
      </Form.Group>
      <Button variant="primary" type="submit">
        Create Task
      </Button>
    </Form>
  );
}

export default TaskCreationForm;
