import { Col, Row } from "react-bootstrap";
import AlertaComponent from "../../components/AlertaComponent";
import NavBarS from "../../components/NavBar";
import { TimerComponent } from "../../components/TimerComponent";
import React from "react";
import EditComponent from "../../components/EditComponent";

export default function Timer() {
  
  const [modalShow, setModalShow] = React.useState(false);

  return (
    <>
      <NavBarS />
      <EditComponent/>
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

