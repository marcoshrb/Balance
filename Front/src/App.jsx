import './App.css'
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AlertaProvider } from "./context/alerta";
import Timer from './pages/Timer';
import ConteudoInicial from './pages/conteudoinicial';

function App() {

  return (
    <>
      <Router>
        <AlertaProvider>
          <Routes>
            <Route path="/timer" element={<Timer />} />
            <Route path="/home" element={<ConteudoInicial />} />

          </Routes>
        </AlertaProvider>
      </Router>
    </>
  )
}

export default App
