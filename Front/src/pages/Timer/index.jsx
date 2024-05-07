import { Col, Row } from "react-bootstrap";
import AlertaComponent from "../../components/AlertaComponent";
import NavBarS from "../../components/NavBar";
import { TimerComponent } from "../../components/TimerComponent";
import React from "react";
import Tamanhos from "../../components/Tamanhos";

export default function Timer() {
  const [modalShow, setModalShow] = React.useState(false);
  return (
    <>
      <NavBarS />
      <Tamanhos/>
      <Col >
        <Row >
          <Col xs={12} sm={8} md={4}>
            <AlertaComponent />
            <TimerComponent />
          </Col>
        </Row>
      </Col>
    </>
  );
}

