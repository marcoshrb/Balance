import React, { useState } from "react";
import { Col, Row } from "react-bootstrap";
import ConteudoInicialComponent from "../../components/ConteudoInicialComponent";
import TimerComponent from "../../components/TimerComponent";
import CronometroComponent from "../../components/CronometroComponent";
import AlertaComponent from "../../components/AlertaComponent";
import NavBarS from "../../components/NavBar";

export default function ConteudoInicial() {
  const [cards, setCards] = useState(null);

  const handleShowTimer = () => {
    setCards("timer");
  };

  const handleShowCronometro = () => {
    setCards("cronometro");
  };

  return (
    <>
    <NavBarS />
      <Col>
        <Row>
          <Col xs={12} sm={8} md={10}>
            <AlertaComponent />
            <ConteudoInicialComponent
              handleShowTimer={handleShowTimer}
              handleShowCronometro={handleShowCronometro}
            />
            {cards === "timer" && <TimerComponent />}
            {cards === "cronometro" && <CronometroComponent />}
          </Col>
        </Row>
      </Col>
    </>
  );
}
