import { useState, useEffect } from 'react';
import { TimerWrapper, CronometroDisplay, AcoesWrapper, Embaixo, StartButton, EscButton } from './styled';
import styled from 'styled-components';

const CustomInput = styled.input`
  padding: 15px;
  font-size: 1.5em;
  border: 2px solid #000000;
  background-color: white;
  color: #000000;
  border-radius: 5px;
  min-width: 500px; 
  text-align: center;
`;

export const TimerComponent = (props) => {

  const { setTempoProva_, handleSubmit_ } = props;

  const [inputTime, setInputTime] = useState(0);
  const [remainingTime, setRemainingTime] = useState(0);
  const [timerActive, setTimerActive] = useState(false);
  const [timeOver, setTimeOver] = useState(false);
  let timeInterval = null;

  const handleInputChange = event => {
    setInputTime(event.target.value);
    setTempoProva_(event.target.value);
  };
  
  const startTimer = () => {
    handleSubmit_();
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
        <div style={{ display : 'flex', justifyContent: 'center', flexDirection: 'column', maxHeight: '100%'}}>

          <div style={{ display: 'flex', justifyContent: 'center', flexDirection: 'column'}}>
            <label>Minutos de prova: </label>
            <CustomInput
              placeholder="Minutos de prova!"
              type="number"
              value={inputTime}
              onChange={handleInputChange}
              disabled={timerActive}
              />
          </div>

          <div style={{display: 'flex', alignItems: 'center', height: '100%'}}>
            <CronometroDisplay>{formatTime(remainingTime)}</CronometroDisplay>
          </div>

          <div style={{height: '30px'}}>
            <AcoesWrapper>
              <Embaixo>
                <div style={{display: 'flex', justifyContent: 'center', width: '100%', flexDirection: 'column'}}>
                  {!timerActive ? (
                    <StartButton onClick={startTimer}>Iniciar</StartButton>
                    ) : (
                      <StartButton onClick={pauseTimer}>Pausar</StartButton>
                      )}
                  <EscButton onClick={resetTimer}>Finalizar</EscButton>
                </div>
              </Embaixo>
            </AcoesWrapper>
          </div>
        </div>

      </>
      )}
    </TimerWrapper>
  );
};