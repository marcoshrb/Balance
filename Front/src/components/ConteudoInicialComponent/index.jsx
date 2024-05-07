import React from 'react';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';

export default function ConteudoInicialComponent({ handleShowTimer, handleShowCronometro }) {
  return (
    <>
    <ButtonGroup aria-label="Basic example">
      <Button onClick={handleShowTimer}  variant="secondary">Timer</Button>
      {/* <Button onClick={handleShowCronometro} variant="secondary">Cronometro</Button> */}
    </ButtonGroup>
    </>
  );
}
