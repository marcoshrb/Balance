import './App.css'
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AlertaProvider } from "./context/alerta";
import Timer from './pages/Timer';

function App() {

  return (
    <>
      <Router>
        <AlertaProvider>
          <Routes>
            <Route path="/" element={<Timer />} />
          </Routes>
        </AlertaProvider>
      </Router>
    </>
  )
}

export default App
