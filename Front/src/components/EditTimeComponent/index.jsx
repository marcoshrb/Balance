import styles from "./styles.module.scss";
import axios from 'axios';
import { useState } from "react";
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';

export default function EditTimeComponent() {

    const [tempoProva, setTempo_Prova] = useState("");
    const [provaLiberada, setProva_Liberada] = useState(false);
    const [f1, setf1] = useState("");
    const [f2, setf2] = useState("");
    const [f3, setf3] = useState("");
    const [f4, setf4] = useState("");
    const [f5, setf5] = useState("");

    async function handleSubmit(e) {
        e.preventDefault();
        setProva_Liberada(true);

        const orderedJson = {
            tempo_Prova: tempoProva,
            prova_Liberada: provaLiberada,
            f1_: f1,
            f2_: f2,
            f3_: f3,
            f4_: f4,
            f5_: f5
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
            <div className={styles.CardInputs}>
                <h1>
                    FORMAS
                </h1>
                <form onSubmit={handleSubmit}>
                    <div style={{ display: 'flex', flexDirection: 'column' }}>
                        <InputGroup className="mb-3">
                            <Form.Control aria-label="Amount (to the nearest dollar)"  
                            onChange={(e) => setTempo_Prova(e.target.value)}
                            placeholder="Tempo de prova"
                            />
                            <InputGroup.Text>min</InputGroup.Text>
                        </InputGroup>
                        <InputGroup className="mb-3">
                            <InputGroup.Text>Δ</InputGroup.Text>
                            <Form.Control aria-label="Amount (to the nearest dollar)" 
                            onChange={(e) => setf1(e.target.value)}
                            placeholder="forma 1"
                            />
                        </InputGroup>
                        <InputGroup className="mb-3">
                            <InputGroup.Text>▢</InputGroup.Text>
                            <Form.Control aria-label="Amount (to the nearest dollar)" 
                            onChange={(e) => setf2(e.target.value)}
                            placeholder="forma 2"
                            />
                        </InputGroup>
                        <InputGroup className="mb-3">
                            <InputGroup.Text>⬠</InputGroup.Text>
                            <Form.Control aria-label="Amount (to the nearest dollar)" 
                            onChange={(e) => setf3(e.target.value)}
                            placeholder="forma 3"
                            />
                        </InputGroup>
                        <InputGroup className="mb-3">
                            <InputGroup.Text>☆</InputGroup.Text>
                            <Form.Control aria-label="Amount (to the nearest dollar)" 
                            onChange={(e) => setf4(e.target.value)}
                            placeholder="forma 4"
                            />
                        </InputGroup>
                        <InputGroup className="mb-3">
                            <InputGroup.Text>◯</InputGroup.Text>
                            <Form.Control aria-label="Amount (to the nearest dollar)" 
                            onChange={(e) => setf5(e.target.value)}
                            placeholder="forma 5"
                            />
                        </InputGroup>
                        <Button variant="success" type='submit'>Salvar</Button>
                    </div>
                </form>
            </div>
        </>
    );
}
