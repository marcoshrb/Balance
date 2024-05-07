// import styles from "./styles.modules.scss";
import axios from 'axios';
import { useState } from "react";



export default function EditComponent() {
    
    const [tempoProva, setTempo_Prova] = useState("");
    const [provaLiberada, setProva_Liberada] = useState(false);
    const [f1, setf1] = useState("");
    const [f2, setf2] = useState("");
    const [f3, setf3] = useState("");
    const [f4, setf4] = useState("");
    const [f5, setf5] = useState("");

    async function handleSubmit(e){
        e.preventDefault();
        setProva_Liberada(true);
    
        const orderedJson = {
            tempo_Prova : tempoProva, 
            prova_Liberada : provaLiberada,
            f1_ : f1,
            f2_ : f2,
            f3_ : f3,
            f4_ : f4,
            f5_ : f5
        };
        // Criando um novo objeto com a ordem dos campos desejada
        console.log(orderedJson);
    
        try {
            const response = await axios.post('http://localhost:8080/challenge', orderedJson);
            console.log("Resposta da API:", response.data);
        } catch (error) {
            console.log("Erro ao fazer requisição:", error);
            
        }
    }
    
  return (
    <>
            <form onSubmit={handleSubmit}>
        <div style={{display: 'flex', flexDirection: 'column'}}>
            <label>tempo de prova</label>
            <input onChange={(e) => setTempo_Prova(e.target.value)}></input>
            <label>f1</label>
            <input onChange={(e) => setf1(e.target.value)}></input>
            <label>f2</label>
            <input onChange={(e) => setf2(e.target.value)}></input>
            <label>f3</label>
            <input onChange={(e) => setf3(e.target.value)}></input>
            <label>f4</label>
            <input onChange={(e) => setf4(e.target.value)}></input>
            <label>f5</label>
            <input onChange={(e) => setf5(e.target.value)}></input>
            <button type='submit'>prova liberada</button>
        </div>
            </form>
    </>
  );
}
