import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AlertaProvider } from "./context/alerta";
import Timer from './pages/Timer';
import ConteudoInicial from './pages/conteudoinicial';
import Edit from './pages/Edit';

function App() {

  return (
    <>
      <Router>
        <AlertaProvider>
          <Routes>
            <Route path="/timer" element={<Timer />} />
            <Route path="/home" element={<ConteudoInicial />} />
            <Route path="/edit" element={<Edit />} />

          </Routes>
        </AlertaProvider>
      </Router>
    </>
  )
}

export default App
