import React from 'react';

export default function ConteudoInicialComponent({ handleShowTimer, handleShowCronometro }) {
  return (
    <>
      <div style={{ display: 'flex', alignItems: 'center', alignContent: 'center',justifyContent: 'center', marginTop: '10px', position: 'absolute', top: '10px', left: '8em' }}>
        <p onClick={handleShowTimer} style={{ marginRight: '10px' }}>
          timer
        </p>
        <p onClick={handleShowCronometro} style={{ marginLeft: '10px' }}>
          cronometro
        </p>
      </div>
    </>
  );
}
