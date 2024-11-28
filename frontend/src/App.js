import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import TaskManager from "./components/TaskManager";
import { Container, Navbar, NavbarBrand } from "react-bootstrap";

function App() {
  return (
    <div className="App d-flex flex-column min-vh-100">
      <Navbar bg="dark" variant="dark" sticky="top" className="mb-4">
        <Container>
          <NavbarBrand>Task Management Application</NavbarBrand>
        </Container>
      </Navbar>


      <Container className="flex-grow-1">
        <TaskManager />
      </Container>
      
      <Navbar bg="dark" variant="dark" className="mt-4">
        <Container>
          <div className="text-center w-100 text-white">
            <p className="mb-0">&copy; {new Date().getFullYear()} Task Management Application</p>
            <small>Created by Kaan Şereflioğlu.</small>
          </div>
        </Container>
      </Navbar>
    </div>
  );
}

export default App;
