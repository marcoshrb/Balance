import React from "react";
import styled from "styled-components";
import backgroundImage from "./folha.png";
import bola from "./pieces/Bola.png";
import estrela from "./pieces/Estrela.png";
import pentagono from "./pieces/Pentagono.png";
import quadrado from "./pieces/Quadrado.png";
import triangulo from "./pieces/Triangulo.png";

const Quadrado = styled.div`
  width: 10vw;
  height: 50vh; 
  background-image: url(${backgroundImage});
  background-size: cover;
  position: absolute;
  top: 0;
  right: 2vw;
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
`;

const Longe = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  height: 100%;
  align-items: center; 
`;

const InputWithImage = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
`;

const Input = styled.input`
  margin-top: 1em; 
  width: 40%;
  padding: 8px;
  border-radius: 4px;
  border: 1px solid #ccc;
  margin-right: 8px;
  background-color: #37448B;
  color: #fff;
  text-align: center;
`;

const FolhaImage = styled.img`
  width: 30px;
  height: 30px;
  margin-right: 8px;
  margin-top: 1em; 

`;

const Botao = styled.button`
  margin-top: 1.5em;
  width: 90%;
  padding: 10px;
  background-color: #37448B;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
`;

const Label = styled.label`
  color: #37448B;;
  font-size: 1em; 
  text-align: center;
  margin-top: 2.2em; 
  font-weight: bold;
`;

function Tamanhos() {
    return (
        <Quadrado>
            <Label>Atualize valor dos elementos</Label>
            <Longe>
                <InputWithImage>
                    <FolhaImage src={bola} alt="Folha" />
                    <Input type="text" placeholder="Bola" />
                </InputWithImage>
                <InputWithImage>
                    <FolhaImage src={estrela} alt="Folha" />
                    <Input type="text" placeholder="Estrela" />
                </InputWithImage>
                <InputWithImage>
                    <FolhaImage src={pentagono} alt="Folha" />
                    <Input type="text" placeholder="Pentagono" />
                </InputWithImage>
                <InputWithImage>
                    <FolhaImage src={quadrado} alt="Folha" />
                    <Input type="text" placeholder="Quadrado" />
                </InputWithImage>
                <InputWithImage>
                    <FolhaImage src={triangulo} alt="Folha" />
                    <Input type="text" placeholder="Triangulo" />
                </InputWithImage>
                <Botao>Atualizar</Botao>
            </Longe>
        </Quadrado>
    );
}

export default Tamanhos;
