import React from "react";
import { ListGroup, Button } from "react-bootstrap";

function TaskList({ tasks, onEdit, onDelete }) {
  return (
    <div>
      <h3>Task List</h3>
      {tasks.length === 0 ? (
        <p>No tasks available.</p>
      ) : (
        <ListGroup>
          {tasks.map((task) => (
            <ListGroup.Item key={task.id}>
              <div className="d-flex justify-content-between align-items-center">
                <div>
                  <h5>{task.title}</h5>
                  <p>{task.description || ""}</p>
                  <small>Created At: {new Date(task.createdAt).toLocaleString()}</small>
                </div>
                <div>
                  <Button
                    variant="warning"
                    className="me-2"
                    onClick={() => onEdit(task)}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="danger"
                    onClick={() => onDelete(task.id)}
                  >
                    Delete
                  </Button>
                </div>
              </div>
            </ListGroup.Item>
          ))}
        </ListGroup>
      )}
    </div>
  );
}

export default TaskList;
