import AlertaComponent from "../../components/AlertaComponent";
import NavBarS from "../../components/NavBar";
import { TimerComponent } from "../../components/TimerComponent";
import { useState } from "react";
import EditComponent from "../../components/EditComponent";
import axios from 'axios';

export default function Timer() {
  
  const [provaLiberada, setProva_Liberada] = useState(false);
  const [tempoProva, setTempoProva] = useState(0);
  const [f1, setF1] = useState(0);
  const [f2, setF2] = useState(0);
  const [f3, setF3] = useState(0);
  const [f4, setF4] = useState(0);
  const [f5, setF5] = useState(0);

  async function handleSubmit() {
      
      setProva_Liberada(true);

      const orderedJson = {
          tempo_Prova: tempoProva,
          prova_Liberada: true,
          f1_: f1,
          f2_: f2,
          f3_: f3,
          f4_: f4,
          f5_: f5
      };
      // Criando um novo objeto com a ordem dos campos desejada
      console.log(orderedJson);

      try {
          const response = await axios.post('https://server-balance.vercel.app/challenge', orderedJson);
          console.log("Resposta da API:", response.data);
      } catch (error) {
          console.log("Erro ao fazer requisição:", error);
      }
  }

  return (
    <>
      <NavBarS />
      <EditComponent 
        setf1={setF1}
        setf2={setF2}
        setf3={setF3}
        setf4={setF4}
        setf5={setF5}
      />
      <AlertaComponent />
      <TimerComponent 
        setTempoProva_ = {setTempoProva}
        handleSubmit_ = {handleSubmit}
      />
      
    </>
  );
}

