import { Col, Row } from "react-bootstrap";
import ConteudoInicial from "../../components/ConteudoInicialComponent";
import AlertaComponent from "../../components/AlertaComponent";
import NavBarS from "../../components/NavBar";

export default function Timer() {
  return (
    <>
      <NavBarS />
      <Col >
        <Row >
          <Col xs={12} sm={8} md={4}>
            <AlertaComponent />
            <ConteudoInicial />
          </Col>
        </Row>
      </Col>
    </>
  );
}
