import React from 'react';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';

export default function ConteudoInicialComponent({ var1, handleShowTimer, handleShowCronometro }) {
  return (
    <>
      <div style={{ display: 'flex', alignItems: 'center', alignContent: 'center', justifyContent: 'center', marginTop: '10px', position: 'absolute', top: '10px', left: '8em' }}>
        <ButtonGroup aria-label="Basic example">
          <Button variant={var1 === "timer" ? "secondary" : "primary"} onClick={handleShowTimer}>TIMER</Button>
          <Button variant={var1 === "cronometro" ? "secondary" : "primary"} onClick={handleShowCronometro}>CRONOMETRO</Button>

        </ButtonGroup>
      </div>
    </>
  );
}
