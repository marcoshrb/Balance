import React, { useState, useEffect } from 'react';
import { TimerWrapper, CronometroDisplay, AcoesWrapper, Embaixo, StartButton, EscButton } from './styled';

export const TimerComponent = () => {
  const [inputTime, setInputTime] = useState('');
  const [remainingTime, setRemainingTime] = useState(0);
  const [timerActive, setTimerActive] = useState(false);
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
      <input
        type="number"
        placeholder="Enter time in minutes"
        value={inputTime}
        onChange={handleInputChange}
        disabled={timerActive}
      />
      <CronometroDisplay>{formatTime(remainingTime)}</CronometroDisplay>
      <AcoesWrapper>
        <Embaixo>
        {!timerActive ? (
          <StartButton onClick={startTimer}>Iniciar</StartButton>
        ) : (
          <StartButton onClick={pauseTimer}>Iniciar</StartButton>
        )}
        <EscButton onClick={resetTimer}>Zerar</EscButton>
        </Embaixo>
      </AcoesWrapper>
    </TimerWrapper>
  );
};

