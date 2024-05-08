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
  width: 10em;
  z-index: 999;
  @media screen  and (max-width: 1024px){
      display: none;
  } 
`;

function NavBarS() {
  return (
    <>
      <Bosch />
      <div style={{display: 'flex', justifyContent: 'center', backgroundColor: 'white'}}>
        <Image src={boschImage} alt="Imagem do Bosch" /> 
      </div>
    </>
  );
}

export default NavBarS;
