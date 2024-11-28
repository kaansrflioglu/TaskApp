import React from "react";
import "./App.css"; 
import TaskManager from "./components/TaskManager"; 

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Task Management Application</h1>
      </header>
      <main>
        <TaskManager /> 
      </main>
    </div>
  );
}

export default App;
