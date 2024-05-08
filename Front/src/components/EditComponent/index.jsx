import styles from "./styles.module.scss";
import axios from 'axios';
import { useState } from "react";
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import Bola from '../../assets/Bola.png';
import Estrela from '../../assets/Estrela.png';
import Pentagono from '../../assets/Pentagono.png';
import Quadrado from '../../assets/Quadrado.png';
import Triangulo from '../../assets/Triangulo.png';
import backgroundImage from "./folha.png";
import styled from "styled-components";

const Quadro = styled.div`
  width: 25rem;
  background-image: url(${backgroundImage});
  background-size: cover;
  position: absolute;
  top: 0;
  right: 2vw;
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  padding-top : 80px;
`;

export default function EditComponent(props) {

    const { setf1, setf2, setf3, setf4, setf5 } = props;

    const [open, setOpen] = useState(false);

    return (
        <>
            <Quadro style={{zIndex : "100", position: 'fixed'}}>
                {open &&

                    <div className={styles.CardInputs}>
                        <form>
                            <div style={{ display: 'flex', flexDirection: 'column' }}>
                                
                                <InputGroup className="mb-3">
                                    <InputGroup.Text><img src={Triangulo} className={styles.ImgsFormas}></img></InputGroup.Text>
                                    <Form.Control aria-label="Amount (to the nearest dollar)"
                                        onChange={(e) => setf1(e.target.value)}
                                        placeholder="forma 1"
                                        type="number"
                                    />
                                </InputGroup>
                                <InputGroup className="mb-3">
                                    <InputGroup.Text><img src={Quadrado} className={styles.ImgsFormas}></img></InputGroup.Text>
                                    <Form.Control aria-label="Amount (to the nearest dollar)"
                                        onChange={(e) => setf2(e.target.value)}
                                        placeholder="forma 2"
                                        type="number"
                                    />
                                </InputGroup>
                                <InputGroup className="mb-3">
                                    <InputGroup.Text><img src={Pentagono} className={styles.ImgsFormas}></img></InputGroup.Text>
                                    <Form.Control aria-label="Amount (to the nearest dollar)"
                                        onChange={(e) => setf3(e.target.value)}
                                        placeholder="forma 3"
                                        type="number"
                                    />
                                </InputGroup>
                                <InputGroup className="mb-3">
                                    <InputGroup.Text><img src={Estrela} className={styles.ImgsFormas}></img></InputGroup.Text>
                                    <Form.Control aria-label="Amount (to the nearest dollar)"
                                        onChange={(e) => setf4(e.target.value)}
                                        placeholder="forma 4"
                                        type="number"
                                    />
                                </InputGroup>
                                <InputGroup className="mb-3">
                                    <InputGroup.Text><img src={Bola} className={styles.ImgsFormas}></img></InputGroup.Text>
                                    <Form.Control aria-label="Amount (to the nearest dollar)"
                                        onChange={(e) => setf5(e.target.value)}
                                        placeholder="forma 5"
                                        type="number"
                                    />
                                </InputGroup>
                            </div>
                        </form>
                    </div>
                }

                <Button variant='warning' className={styles.CloseEditButton} onClick={() => setOpen(!open)}>Editar</Button>
            </Quadro>
        </>
    );
}
