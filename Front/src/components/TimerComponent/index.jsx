import React, { useState, useEffect } from 'react';
import { TimerWrapper, CronometroDisplay, AcoesWrapper, Embaixo, StartButton, EscButton } from './styled';
import styled from 'styled-components';

const CustomInput = styled.input`
  padding: 15px;
  font-size: 1.5em;
  border: 2px solid #fff;
  border-radius: 5px;
  width: 500px; 
  text-align: center;
`;

export const TimerComponent = () => {
  const [inputTime, setInputTime] = useState('');
  const [remainingTime, setRemainingTime] = useState(0);
  const [timerActive, setTimerActive] = useState(false);
  const [timeOver, setTimeOver] = useState(false);
  let timeInterval = null;

  const handleInputChange = event => {
    setInputTime(event.target.value);
  };

  const startTimer = () => {
    if (inputTime.trim() !== '' && parseInt(inputTime) > 0 && !timerActive) {
      const totalTime = parseInt(inputTime) * 60;
      setRemainingTime(totalTime);
      setTimerActive(true);

      timeInterval = setInterval(() => {
        setRemainingTime(prevTime => {
          if (prevTime > 0) {
            return prevTime - 1;
          } else {
            clearInterval(timeInterval);
            setTimerActive(false);
            setTimeOver(true);
            return 0;
          }
        });
      }, 1000);
    }
  };

  const pauseTimer = () => {
    clearInterval(timeInterval);
    setTimerActive(false);
  };

  const resetTimer = () => {
    clearInterval(timeInterval);
    setTimerActive(false);
    setInputTime('');
    setRemainingTime(0);
    setTimeOver(false);
  };

  useEffect(() => {
    return () => clearInterval(timeInterval);
  }, []);

  const formatTime = time => {
    const minutes = Math.floor(time / 60);
    const seconds = time % 60;
    const formattedMinutes = String(minutes).padStart(2, '0');
    const formattedSeconds = String(seconds).padStart(2, '0');
    return `${formattedMinutes}:${formattedSeconds}`;
  };

  return (
    <TimerWrapper className="TimerComponent">
      {timeOver ? (
        <>
          <div style={{ fontSize: '2em', marginBottom: '1em' }}>Seu tempo acabou!</div>
          <Embaixo>
            <StartButton onClick={resetTimer}>Reiniciar</StartButton>
          </Embaixo>
        </>
      ) : (
        <>
          <div style={{ display: 'flex', justifyContent: 'center' }}>
            <CustomInput
              type="number"
              placeholder="Digite aqui quantos minutos terá de prova!"
              value={inputTime}
              onChange={handleInputChange}
              disabled={timerActive}
            />
          </div>
          <CronometroDisplay>{formatTime(remainingTime)}</CronometroDisplay>
          <AcoesWrapper>
            <Embaixo>
              {!timerActive ? (
                <StartButton onClick={startTimer}>Iniciar</StartButton>
              ) : (
                <StartButton onClick={pauseTimer}>Pausar</StartButton>
              )}
              <EscButton onClick={resetTimer}>Zerar</EscButton>
            </Embaixo>
          </AcoesWrapper>
        </>
      )}
    </TimerWrapper>
  );
};