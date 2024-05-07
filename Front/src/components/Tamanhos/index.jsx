import React from "react";
import styled from "styled-components";
import backgroundImage from "./folha.png";

const Quadrado = styled.div`
  width: 15vw;
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
`;

const InputWithImage = styled.div`
  display: flex;
  align-items: center;
`;

const Input = styled.input`
margin-top: 3em;
  width: 90%;
  padding: 8px;
  border-radius: 4px;
  border: 1px solid #ccc;
  margin-right: 8px;
  background-color: #37448B;
`;

const FolhaImage = styled.img`
margin-top: 2em;
  width: 30px;
  height: 30px;
  margin-right: 8px;
`;

const Botao = styled.button`
margin-top: 1.5em;
  width: 100%;
  padding: 10px;
  background-color: #37448B;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
`;

function Tamanhos() {
    return (
        <Quadrado>
            <Longe>
                <InputWithImage>
                    <FolhaImage src={backgroundImage} alt="Folha" />
                    <Input type="text" placeholder="Digite o valor do elemento" />
                </InputWithImage>
                <InputWithImage>
                    <FolhaImage src={backgroundImage} alt="Folha" />
                    <Input type="text" placeholder="Digite o valor do elemento" />
                </InputWithImage>
                <InputWithImage>
                    <FolhaImage src={backgroundImage} alt="Folha" />
                    <Input type="text" placeholder="Digite o valor do elemento" />
                </InputWithImage>
                <InputWithImage>
                    <FolhaImage src={backgroundImage} alt="Folha" />
                    <Input type="text" placeholder="Digite o valor do elemento" />
                </InputWithImage>
                <InputWithImage>
                    <FolhaImage src={backgroundImage} alt="Folha" />
                    <Input type="text" placeholder="Digite o valor do elemento" />
                </InputWithImage>
                <Botao>Valores definidos para partida</Botao>
            </Longe>
        </Quadrado>
    );
}

export default Tamanhos;
