import React from "react";
import styled from "styled-components";
import boschImage from "./img/bosch.png"; 
import backgroundImage from "./img/colorStripe.png";

export const Bosch = styled.div`
  background-image: url(${backgroundImage});
  background-size: cover;
  height: 6px;
  width: 100%;
  position: fixed;
  top: 0;
  left: 0;
  z-index: 1000;
`;


export const Image = styled.img`
  position: fixed;
  top: 1%;
  width: 10em;
  z-index: 999;
`;

export const DivImg = styled.div`
  width : 100%;
  display : flex;
  flex-direction: row;
  justify-content: center;
`;

function NavBarS() {
  return (
    <>
      <Bosch />
      <DivImg>
        <Image src={boschImage} alt="Imagem do Bosch" /> 
      </DivImg>
    </>
  );
}

export default NavBarS;
