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
  top: 3%;
  left: 20%;
  width: 10em;
  z-index: 999;
`;

function NavBarS() {
  return (
    <>
      <Bosch />
      <Image src={boschImage} alt="Imagem do Bosch" /> 
    </>
  );
}

export default NavBarS;
